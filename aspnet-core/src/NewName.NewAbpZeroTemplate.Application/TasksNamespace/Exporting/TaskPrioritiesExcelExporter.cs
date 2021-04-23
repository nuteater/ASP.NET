﻿using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using NewName.NewAbpZeroTemplate.DataExporting.Excel.NPOI;
using NewName.NewAbpZeroTemplate.TasksNamespace.Dtos;
using NewName.NewAbpZeroTemplate.Dto;
using NewName.NewAbpZeroTemplate.Storage;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Exporting
{
    public class TaskPrioritiesExcelExporter : NpoiExcelExporterBase, ITaskPrioritiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public TaskPrioritiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTaskPriorityForViewDto> taskPriorities)
        {
            return CreateExcelPackage(
                "TaskPriorities.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("TaskPriorities"));

                    AddHeader(
                        sheet,
                        L("Name")
                        );

                    AddObjects(
                        sheet, 2, taskPriorities,
                        _ => _.TaskPriority.Name
                        );

					
					
                });
        }
    }
}
