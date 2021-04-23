using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITaskPrioritiesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTaskPriorityForViewDto>> GetAll(GetAllTaskPrioritiesInput input);

        Task<GetTaskPriorityForViewDto> GetTaskPriorityForView(int id);

		Task<GetTaskPriorityForEditOutput> GetTaskPriorityForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTaskPriorityDto input);

		Task Delete(EntityDto input);

		
    }
}