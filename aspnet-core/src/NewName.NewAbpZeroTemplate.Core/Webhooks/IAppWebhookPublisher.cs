using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.Authorization.Users;

namespace NewName.NewAbpZeroTemplate.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
