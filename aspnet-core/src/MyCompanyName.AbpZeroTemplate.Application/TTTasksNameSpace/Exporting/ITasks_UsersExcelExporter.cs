using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public interface ITasks_UsersExcelExporter
    {
        FileDto ExportToFile(List<GetTasks_UserForViewDto> tasks_Users);
    }
}