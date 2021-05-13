using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    public interface ITaskTopicsAppService : IApplicationService
    {
        Task<PagedResultDto<GetTaskTopicForViewDto>> GetAll(GetAllTaskTopicsInput input);

        Task<GetTaskTopicForViewDto> GetTaskTopicForView(int id);

        Task<GetTaskTopicForEditOutput> GetTaskTopicForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditTaskTopicDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetTaskTopicsToExcel(GetAllTaskTopicsForExcelInput input);

    }
}