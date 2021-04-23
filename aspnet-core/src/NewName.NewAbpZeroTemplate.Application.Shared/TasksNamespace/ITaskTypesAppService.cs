using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITaskTypesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTaskTypeForViewDto>> GetAll(GetAllTaskTypesInput input);

        Task<GetTaskTypeForViewDto> GetTaskTypeForView(int id);

		Task<GetTaskTypeForEditOutput> GetTaskTypeForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTaskTypeDto input);

		Task Delete(EntityDto input);

		
    }
}