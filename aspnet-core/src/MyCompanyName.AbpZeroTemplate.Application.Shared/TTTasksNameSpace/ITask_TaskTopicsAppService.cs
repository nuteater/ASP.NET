using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITask_TaskTopicsAppService : IApplicationService
    {
        Task<PagedResultDto<GetTask_TaskTopicForViewDto>> GetAll(GetAllTask_TaskTopicsInput input);

        Task<GetTask_TaskTopicForViewDto> GetTask_TaskTopicForView(int id);

        Task<GetTask_TaskTopicForEditOutput> GetTask_TaskTopicForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTask_TaskTopicDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTask_TaskTopicsToExcel(GetAllTask_TaskTopicsForExcelInput input);

        Task<PagedResultDto<Task_TaskTopicTTTaskLookupTableDto>> GetAllTTTaskForLookupTable(GetAllForLookupTableInput input);

        Task<PagedResultDto<Task_TaskTopicTaskTopicLookupTableDto>> GetAllTaskTopicForLookupTable(GetAllForLookupTableInput input);

    }
}