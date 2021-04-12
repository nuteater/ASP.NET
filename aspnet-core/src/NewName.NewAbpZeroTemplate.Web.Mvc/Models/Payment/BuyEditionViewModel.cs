using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Editions;
using NewName.NewAbpZeroTemplate.Editions.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
