using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITTTasksAppService : IApplicationService
    {
        Task<PagedResultDto<GetTTTaskForViewDto>> GetAll(GetAllTTTasksInput input);

        Task<GetTTTaskForViewDto> GetTTTaskForView(int id);

        Task<GetTTTaskForEditOutput> GetTTTaskForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTTTaskDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTTTasksToExcel(GetAllTTTasksForExcelInput input);

        Task<PagedResultDto<TTTaskTaskTypeLookupTableDto>> GetAllTaskTypeForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<TTTaskTaskPriorityLookupTableDto>> GetAllTaskPriorityForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<TTTaskSubtaskLookupTableDto>> GetAllSubtaskForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<TTTaskTaskHistoryLookupTableDto>> GetAllTaskHistoryForLookupTable(GetAllForLookupTableInput input);

    }
}