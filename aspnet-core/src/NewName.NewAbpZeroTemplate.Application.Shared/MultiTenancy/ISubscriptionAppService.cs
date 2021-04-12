using System.Threading.Tasks;
using Abp.Application.Services;

namespace NewName.NewAbpZeroTemplate.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
