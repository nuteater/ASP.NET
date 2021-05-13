using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITaskPrioritiesAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskPriorityForViewDto>> GetAll(GetAllTaskPrioritiesInput input);

        Task<GetTaskPriorityForViewDto> GetTaskPriorityForView(int id);

        Task<GetTaskPriorityForEditOutput> GetTaskPriorityForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskPriorityDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTaskPrioritiesToExcel(GetAllTaskPrioritiesForExcelInput input);

    }
}