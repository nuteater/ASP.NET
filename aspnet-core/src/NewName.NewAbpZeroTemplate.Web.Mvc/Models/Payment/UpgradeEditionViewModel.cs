using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Editions.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments;

namespace NewName.NewAbpZeroTemplate.Web.Models.Payment
{
    public class UpgradeEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public SubscriptionPaymentType SubscriptionPaymentType { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}