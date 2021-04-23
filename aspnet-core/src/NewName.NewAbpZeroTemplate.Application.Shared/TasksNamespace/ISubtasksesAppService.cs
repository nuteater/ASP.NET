using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;


namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
    public interface ISubtasksesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetSubtasksForViewDto>> GetAll(GetAllSubtasksesInput input);

        Task<GetSubtasksForViewDto> GetSubtasksForView(int id);

		Task<GetSubtasksForEditOutput> GetSubtasksForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditSubtasksDto input);

		Task Delete(EntityDto input);

		
    }
}