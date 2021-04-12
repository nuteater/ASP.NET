using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NewName.NewAbpZeroTemplate.Configure;
using NewName.NewAbpZeroTemplate.Startup;
using NewName.NewAbpZeroTemplate.Test.Base;

namespace NewName.NewAbpZeroTemplate.GraphQL.Tests
{
    [DependsOn(
        typeof(NewAbpZeroTemplateGraphQLModule),
        typeof(NewAbpZeroTemplateTestBaseModule))]
    public class NewAbpZeroTemplateGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateGraphQLTestModule).GetAssembly());
        }
    }
}