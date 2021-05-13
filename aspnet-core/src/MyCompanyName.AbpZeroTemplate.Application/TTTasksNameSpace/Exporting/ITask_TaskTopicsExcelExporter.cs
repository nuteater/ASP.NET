using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public interface ITask_TaskTopicsExcelExporter
    {
        FileDto ExportToFile(List<GetTask_TaskTopicForViewDto> task_TaskTopics);
    }
}