using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Stripe.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}