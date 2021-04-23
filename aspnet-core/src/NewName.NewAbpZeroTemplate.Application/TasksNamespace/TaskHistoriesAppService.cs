

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
	[AbpAuthorize(AppPermissions.Pages_TaskHistories)]
    public class TaskHistoriesAppService : NewAbpZeroTemplateAppServiceBase, ITaskHistoriesAppService
    {
		 private readonly IRepository<TaskHistory> _taskHistoryRepository;
		 

		  public TaskHistoriesAppService(IRepository<TaskHistory> taskHistoryRepository ) 
		  {
			_taskHistoryRepository = taskHistoryRepository;
			
		  }

		 public async Task<PagedResultDto<GetTaskHistoryForViewDto>> GetAll(GetAllTaskHistoriesInput input)
         {
			
			var filteredTaskHistories = _taskHistoryRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Description.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter),  e => e.Description == input.DescriptionFilter);

			var pagedAndFilteredTaskHistories = filteredTaskHistories
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var taskHistories = from o in pagedAndFilteredTaskHistories
                         select new GetTaskHistoryForViewDto() {
							TaskHistory = new TaskHistoryDto
							{
                                Description = o.Description,
                                Id = o.Id
							}
						};

            var totalCount = await filteredTaskHistories.CountAsync();

            return new PagedResultDto<GetTaskHistoryForViewDto>(
                totalCount,
                await taskHistories.ToListAsync()
            );
         }
		 
		 public async Task<GetTaskHistoryForViewDto> GetTaskHistoryForView(int id)
         {
            var taskHistory = await _taskHistoryRepository.GetAsync(id);

            var output = new GetTaskHistoryForViewDto { TaskHistory = ObjectMapper.Map<TaskHistoryDto>(taskHistory) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_TaskHistories_Edit)]
		 public async Task<GetTaskHistoryForEditOutput> GetTaskHistoryForEdit(EntityDto input)
         {
            var taskHistory = await _taskHistoryRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetTaskHistoryForEditOutput {TaskHistory = ObjectMapper.Map<CreateOrEditTaskHistoryDto>(taskHistory)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditTaskHistoryDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskHistories_Create)]
		 protected virtual async Task Create(CreateOrEditTaskHistoryDto input)
         {
            var taskHistory = ObjectMapper.Map<TaskHistory>(input);

			
			if (AbpSession.TenantId != null)
			{
				taskHistory.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _taskHistoryRepository.InsertAsync(taskHistory);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskHistories_Edit)]
		 protected virtual async Task Update(CreateOrEditTaskHistoryDto input)
         {
            var taskHistory = await _taskHistoryRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, taskHistory);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskHistories_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _taskHistoryRepository.DeleteAsync(input.Id);
         } 
    }
}