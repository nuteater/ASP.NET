using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public interface ITaskTopicsExcelExporter
    {
        FileDto ExportToFile(List<GetTaskTopicForViewDto> taskTopics);
    }
}