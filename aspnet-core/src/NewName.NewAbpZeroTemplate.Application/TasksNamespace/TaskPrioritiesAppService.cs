

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
	[AbpAuthorize(AppPermissions.Pages_TaskPriorities)]
    public class TaskPrioritiesAppService : NewAbpZeroTemplateAppServiceBase, ITaskPrioritiesAppService
    {
		 private readonly IRepository<TaskPriority> _taskPriorityRepository;
		 

		  public TaskPrioritiesAppService(IRepository<TaskPriority> taskPriorityRepository ) 
		  {
			_taskPriorityRepository = taskPriorityRepository;
			
		  }

		 public async Task<PagedResultDto<GetTaskPriorityForViewDto>> GetAll(GetAllTaskPrioritiesInput input)
         {
			
			var filteredTaskPriorities = _taskPriorityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter);

			var pagedAndFilteredTaskPriorities = filteredTaskPriorities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var taskPriorities = from o in pagedAndFilteredTaskPriorities
                         select new GetTaskPriorityForViewDto() {
							TaskPriority = new TaskPriorityDto
							{
                                Name = o.Name,
                                Id = o.Id
							}
						};

            var totalCount = await filteredTaskPriorities.CountAsync();

            return new PagedResultDto<GetTaskPriorityForViewDto>(
                totalCount,
                await taskPriorities.ToListAsync()
            );
         }
		 
		 public async Task<GetTaskPriorityForViewDto> GetTaskPriorityForView(int id)
         {
            var taskPriority = await _taskPriorityRepository.GetAsync(id);

            var output = new GetTaskPriorityForViewDto { TaskPriority = ObjectMapper.Map<TaskPriorityDto>(taskPriority) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Edit)]
		 public async Task<GetTaskPriorityForEditOutput> GetTaskPriorityForEdit(EntityDto input)
         {
            var taskPriority = await _taskPriorityRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetTaskPriorityForEditOutput {TaskPriority = ObjectMapper.Map<CreateOrEditTaskPriorityDto>(taskPriority)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditTaskPriorityDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Create)]
		 protected virtual async Task Create(CreateOrEditTaskPriorityDto input)
         {
            var taskPriority = ObjectMapper.Map<TaskPriority>(input);

			
			if (AbpSession.TenantId != null)
			{
				taskPriority.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _taskPriorityRepository.InsertAsync(taskPriority);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Edit)]
		 protected virtual async Task Update(CreateOrEditTaskPriorityDto input)
         {
            var taskPriority = await _taskPriorityRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, taskPriority);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskPriorities_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _taskPriorityRepository.DeleteAsync(input.Id);
         } 
    }
}