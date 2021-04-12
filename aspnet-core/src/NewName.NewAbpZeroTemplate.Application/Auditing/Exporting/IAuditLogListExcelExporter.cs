using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Auditing.Dto;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
