using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.MultiTenancy;
using NewName.NewAbpZeroTemplate.MultiTenancy.Dto;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}