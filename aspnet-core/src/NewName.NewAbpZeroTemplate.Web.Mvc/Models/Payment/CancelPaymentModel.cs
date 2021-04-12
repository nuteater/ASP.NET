using NewName.NewAbpZeroTemplate.MultiTenancy.Payments;

namespace NewName.NewAbpZeroTemplate.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}