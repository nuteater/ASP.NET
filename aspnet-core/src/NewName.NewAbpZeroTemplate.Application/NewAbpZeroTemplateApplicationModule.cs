using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NewName.NewAbpZeroTemplate.Authorization;

namespace NewName.NewAbpZeroTemplate
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(NewAbpZeroTemplateApplicationSharedModule),
        typeof(NewAbpZeroTemplateCoreModule)
        )]
    public class NewAbpZeroTemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateApplicationModule).GetAssembly());
        }
    }
}