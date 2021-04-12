using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.MultiTenancy.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
