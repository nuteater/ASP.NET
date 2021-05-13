using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Exporting
{
    public interface ITaskTypesExcelExporter
    {
        FileDto ExportToFile(List<GetTaskTypeForViewDto> taskTypes);
    }
}