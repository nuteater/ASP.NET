using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Exporting
{
    public interface ITaskPrioritiesExcelExporter
    {
        FileDto ExportToFile(List<GetTaskPriorityForViewDto> taskPriorities);
    }
}