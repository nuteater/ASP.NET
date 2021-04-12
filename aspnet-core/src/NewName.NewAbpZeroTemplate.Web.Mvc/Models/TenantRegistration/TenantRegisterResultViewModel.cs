using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.MultiTenancy.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}