using Abp.Auditing;
using NewName.NewAbpZeroTemplate.Configuration.Dto;

namespace NewName.NewAbpZeroTemplate.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}