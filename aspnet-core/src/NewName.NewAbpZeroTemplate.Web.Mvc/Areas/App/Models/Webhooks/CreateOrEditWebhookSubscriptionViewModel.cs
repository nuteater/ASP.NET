using Abp.Application.Services.Dto;
using Abp.Webhooks;
using NewName.NewAbpZeroTemplate.WebHooks.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
