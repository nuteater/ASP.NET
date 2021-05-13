using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITaskHistoriesAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskHistoryForViewDto>> GetAll(GetAllTaskHistoriesInput input);

        Task<GetTaskHistoryForViewDto> GetTaskHistoryForView(int id);

        Task<GetTaskHistoryForEditOutput> GetTaskHistoryForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskHistoryDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTaskHistoriesToExcel(GetAllTaskHistoriesForExcelInput input);

    }
}