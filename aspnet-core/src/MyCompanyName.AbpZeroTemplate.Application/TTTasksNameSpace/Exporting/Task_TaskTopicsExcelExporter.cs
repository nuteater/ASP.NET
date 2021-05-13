using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyCompanyName.AbpZeroTemplate.DataExporting.Excel.NPOI;
using MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using MyCompanyName.AbpZeroTemplate.Storage;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Exporting
{
    public class Task_TaskTopicsExcelExporter : NpoiExcelExporterBase, ITask_TaskTopicsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public Task_TaskTopicsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTask_TaskTopicForViewDto> task_TaskTopics)
        {
            return CreateExcelPackage(
                "Task_TaskTopics.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Task_TaskTopics"));

                    AddHeader(
                        sheet,
                        (L("TTTask")) + L("Name"),
                        (L("TaskTopic")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, task_TaskTopics,
                        _ => _.TTTaskName,
                        _ => _.TaskTopicName
                        );

                });
        }
    }
}