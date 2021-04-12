using System.Threading.Tasks;
using Abp.Webhooks;

namespace NewName.NewAbpZeroTemplate.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
