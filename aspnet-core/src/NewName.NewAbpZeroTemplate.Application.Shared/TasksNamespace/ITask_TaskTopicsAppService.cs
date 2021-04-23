using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITask_TaskTopicsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTask_TaskTopicForViewDto>> GetAll(GetAllTask_TaskTopicsInput input);

        Task<GetTask_TaskTopicForViewDto> GetTask_TaskTopicForView(int id);

		Task<GetTask_TaskTopicForEditOutput> GetTask_TaskTopicForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTask_TaskTopicDto input);

		Task Delete(EntityDto input);

		
		Task<PagedResultDto<Task_TaskTopicTaskTopicLookupTableDto>> GetAllTaskTopicForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<Task_TaskTopicTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input);
		
    }
}