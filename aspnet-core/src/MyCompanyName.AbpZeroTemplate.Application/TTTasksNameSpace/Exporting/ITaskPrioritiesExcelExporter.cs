using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public interface ITaskPrioritiesExcelExporter
    {
        FileDto ExportToFile(List<GetTaskPriorityForViewDto> taskPriorities);
    }
}