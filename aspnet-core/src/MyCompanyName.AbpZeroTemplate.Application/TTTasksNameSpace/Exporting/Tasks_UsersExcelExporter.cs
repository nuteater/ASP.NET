using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyCompanyName.AbpZeroTemplate.DataExporting.Excel.NPOI;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public class Tasks_UsersExcelExporter : NpoiExcelExporterBase, ITasks_UsersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public Tasks_UsersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTasks_UserForViewDto> tasks_Users)
        {
            return CreateExcelPackage(
                "Tasks_Users.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Tasks_Users"));

                    AddHeader(
                        sheet,
                        (L("TTTask")) + L("Name"),
                        (L("User")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, tasks_Users,
                        _ => _.TTTaskName,
                        _ => _.UserName
                        );

                });
        }
    }
}