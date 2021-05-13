using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ISubtasksAppService : IApplicationService
    {
        Task<PagedResultDto<GetSubtaskForViewDto>> GetAll(GetAllSubtasksInput input);

        Task<GetSubtaskForViewDto> GetSubtaskForView(int id);

        Task<GetSubtaskForEditOutput> GetSubtaskForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSubtaskDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSubtasksToExcel(GetAllSubtasksForExcelInput input);

    }
}