using Microsoft.Extensions.DependencyInjection;
using NewName.NewAbpZeroTemplate.HealthChecks;

namespace NewName.NewAbpZeroTemplate.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<NewAbpZeroTemplateDbContextHealthCheck>("Database Connection");
            builder.AddCheck<NewAbpZeroTemplateDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
