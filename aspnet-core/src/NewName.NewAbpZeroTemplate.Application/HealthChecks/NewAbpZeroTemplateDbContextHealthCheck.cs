using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NewName.NewAbpZeroTemplate.EntityFrameworkCore;

namespace NewName.NewAbpZeroTemplate.HealthChecks
{
    public class NewAbpZeroTemplateDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public NewAbpZeroTemplateDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("NewAbpZeroTemplateDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("NewAbpZeroTemplateDbContext could not connect to database"));
        }
    }
}
