using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace
{
    public interface ITaskTypesAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskTypeForViewDto>> GetAll(GetAllTaskTypesInput input);

        Task<GetTaskTypeForViewDto> GetTaskTypeForView(int id);

        Task<GetTaskTypeForEditOutput> GetTaskTypeForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskTypeDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTaskTypesToExcel(GetAllTaskTypesForExcelInput input);

    }
}