using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITasks_UsersAppService : IApplicationService
    {
        Task<PagedResultDto<GetTasks_UserForViewDto>> GetAll(GetAllTasks_UsersInput input);

        Task<GetTasks_UserForViewDto> GetTasks_UserForView(int id);

        Task<GetTasks_UserForEditOutput> GetTasks_UserForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTasks_UserDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTasks_UsersToExcel(GetAllTasks_UsersForExcelInput input);

        Task<PagedResultDto<Tasks_UserTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<Tasks_UserUserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);

    }
}