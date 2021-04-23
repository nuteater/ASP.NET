using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using NewName.NewAbpZeroTemplate.DataExporting.Excel.NPOI;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;
using NewName.NewAbpZeroTemplate.Storage;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Exporting
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
                        L("Description"),
                        (L("TaskType")) + L("Name"),
                        (L("TaskPriority")) + L("Name"),
                        (L("Subtasks")) + L("Description"),
                        (L("TaskHistory")) + L("Description")
                        );

                    AddObjects(
                        sheet, 2, ttTasks,
                        _ => _.TTTask.Name,
                        _ => _.TTTask.Description,
                        _ => _.TaskTypeName,
                        _ => _.TaskPriorityName,
                        _ => _.SubtasksDescription,
                        _ => _.TaskHistoryDescription
                        );

					
					
                });
        }
    }
}
