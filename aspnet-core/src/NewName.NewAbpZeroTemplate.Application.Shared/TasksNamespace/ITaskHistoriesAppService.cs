using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ITaskHistoriesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTaskHistoryForViewDto>> GetAll(GetAllTaskHistoriesInput input);

        Task<GetTaskHistoryForViewDto> GetTaskHistoryForView(int id);

		Task<GetTaskHistoryForEditOutput> GetTaskHistoryForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTaskHistoryDto input);

		Task Delete(EntityDto input);

		
    }
}