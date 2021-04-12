using NewName.NewAbpZeroTemplate.Editions.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < NewAbpZeroTemplateConsts.MinimumUpgradePaymentAmount;
        }
    }
}
