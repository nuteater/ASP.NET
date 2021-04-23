using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Exporting
{
    public interface ITTTasksExcelExporter
    {
        FileDto ExportToFile(List<GetTTTaskForViewDto> ttTasks);
    }
}