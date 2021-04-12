using NewName.NewAbpZeroTemplate.Editions;
using NewName.NewAbpZeroTemplate.Editions.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments;
using NewName.NewAbpZeroTemplate.Security;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
