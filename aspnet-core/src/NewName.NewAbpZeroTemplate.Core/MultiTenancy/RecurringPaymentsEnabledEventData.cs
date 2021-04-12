using Abp.Events.Bus;

namespace NewName.NewAbpZeroTemplate.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}