using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITaskTopicsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTaskTopicForViewDto>> GetAll(GetAllTaskTopicsInput input);

        Task<GetTaskTopicForViewDto> GetTaskTopicForView(int id);

		Task<GetTaskTopicForEditOutput> GetTaskTopicForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTaskTopicDto input);

		Task Delete(EntityDto input);

		
    }
}