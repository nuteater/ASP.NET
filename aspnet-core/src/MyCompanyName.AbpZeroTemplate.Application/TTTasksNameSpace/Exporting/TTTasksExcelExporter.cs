using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyCompanyName.AbpZeroTemplate.DataExporting.Excel.NPOI;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public class TTTasksExcelExporter : NpoiExcelExporterBase, ITTTasksExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public TTTasksExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTTTaskForViewDto> ttTasks)
        {
            return CreateExcelPackage(
                "TTTasks.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("TTTasks"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Discription"),
                        (L("TaskType")) + L("Name"),
                        (L("TaskPriority")) + L("Name"),
                        (L("Subtask")) + L("Description"),
                        (L("TaskHistory")) + L("Description")
                        );

                    AddObjects(
                        sheet, 2, ttTasks,
                        _ => _.TTTask.Name,
                        _ => _.TTTask.Discription,
                        _ => _.TaskTypeName,
                        _ => _.TaskPriorityName,
                        _ => _.SubtaskDescription,
                        _ => _.TaskHistoryDescription
                        );

                });
        }
    }
}