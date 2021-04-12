using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Sessions.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}