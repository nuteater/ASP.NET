

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
	[AbpAuthorize(AppPermissions.Pages_TaskTopics)]
    public class TaskTopicsAppService : NewAbpZeroTemplateAppServiceBase, ITaskTopicsAppService
    {
		 private readonly IRepository<TaskTopic> _taskTopicRepository;
		 

		  public TaskTopicsAppService(IRepository<TaskTopic> taskTopicRepository ) 
		  {
			_taskTopicRepository = taskTopicRepository;
			
		  }

		 public async Task<PagedResultDto<GetTaskTopicForViewDto>> GetAll(GetAllTaskTopicsInput input)
         {
			
			var filteredTaskTopics = _taskTopicRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter);

			var pagedAndFilteredTaskTopics = filteredTaskTopics
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var taskTopics = from o in pagedAndFilteredTaskTopics
                         select new GetTaskTopicForViewDto() {
							TaskTopic = new TaskTopicDto
							{
                                Name = o.Name,
                                Id = o.Id
							}
						};

            var totalCount = await filteredTaskTopics.CountAsync();

            return new PagedResultDto<GetTaskTopicForViewDto>(
                totalCount,
                await taskTopics.ToListAsync()
            );
         }
		 
		 public async Task<GetTaskTopicForViewDto> GetTaskTopicForView(int id)
         {
            var taskTopic = await _taskTopicRepository.GetAsync(id);

            var output = new GetTaskTopicForViewDto { TaskTopic = ObjectMapper.Map<TaskTopicDto>(taskTopic) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_TaskTopics_Edit)]
		 public async Task<GetTaskTopicForEditOutput> GetTaskTopicForEdit(EntityDto input)
         {
            var taskTopic = await _taskTopicRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetTaskTopicForEditOutput {TaskTopic = ObjectMapper.Map<CreateOrEditTaskTopicDto>(taskTopic)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditTaskTopicDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTopics_Create)]
		 protected virtual async Task Create(CreateOrEditTaskTopicDto input)
         {
            var taskTopic = ObjectMapper.Map<TaskTopic>(input);

			
			if (AbpSession.TenantId != null)
			{
				taskTopic.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _taskTopicRepository.InsertAsync(taskTopic);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTopics_Edit)]
		 protected virtual async Task Update(CreateOrEditTaskTopicDto input)
         {
            var taskTopic = await _taskTopicRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, taskTopic);
         }

		 [AbpAuthorize(AppPermissions.Pages_TaskTopics_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _taskTopicRepository.DeleteAsync(input.Id);
         } 
    }
}