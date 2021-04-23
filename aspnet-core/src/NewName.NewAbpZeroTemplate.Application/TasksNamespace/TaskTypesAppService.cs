

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[AbpAuthorize(AppPermissions.Pages_TaskTypes)]
    public class TaskTypesAppService : NewAbpZeroTemplateAppServiceBase, ITaskTypesAppService
    {
		 private readonly IRepository<TaskType> _taskTypeRepository;
		 

		  public TaskTypesAppService(IRepository<TaskType> taskTypeRepository ) 
		  {
			_taskTypeRepository = taskTypeRepository;
			
		  }

		 public async Task<PagedResultDto<GetTaskTypeForViewDto>> GetAll(GetAllTaskTypesInput input)
         {
			
			var filteredTaskTypes = _taskTypeRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter);

			var pagedAndFilteredTaskTypes = filteredTaskTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var taskTypes = from o in pagedAndFilteredTaskTypes
                         select new GetTaskTypeForViewDto() {
							TaskType = new TaskTypeDto
							{
                                Name = o.Name,
                                Id = o.Id
							}
						};

            var totalCount = await filteredTaskTypes.CountAsync();

            return new PagedResultDto<GetTaskTypeForViewDto>(
                totalCount,
                await taskTypes.ToListAsync()
            );
         }
		 
		 public async Task<GetTaskTypeForViewDto> GetTaskTypeForView(int id)
         {
            var taskType = await _taskTypeRepository.GetAsync(id);

            var output = new GetTaskTypeForViewDto { TaskType = ObjectMapper.Map<TaskTypeDto>(taskType) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_TaskTypes_Edit)]
		 public async Task<GetTaskTypeForEditOutput> GetTaskTypeForEdit(EntityDto input)
         {
            var taskType = await _taskTypeRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetTaskTypeForEditOutput {TaskType = ObjectMapper.Map<CreateOrEditTaskTypeDto>(taskType)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditTaskTypeDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTypes_Create)]
		 protected virtual async Task Create(CreateOrEditTaskTypeDto input)
         {
            var taskType = ObjectMapper.Map<TaskType>(input);

			
			if (AbpSession.TenantId != null)
			{
				taskType.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _taskTypeRepository.InsertAsync(taskType);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTypes_Edit)]
		 protected virtual async Task Update(CreateOrEditTaskTypeDto input)
         {
            var taskType = await _taskTypeRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, taskType);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTypes_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _taskTypeRepository.DeleteAsync(input.Id);
         } 
    }
}