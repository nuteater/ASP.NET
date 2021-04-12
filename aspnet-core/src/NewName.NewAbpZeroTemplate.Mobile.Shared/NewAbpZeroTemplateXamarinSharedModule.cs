using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    [DependsOn(typeof(NewAbpZeroTemplateClientModule), typeof(AbpAutoMapperModule))]
    public class NewAbpZeroTemplateXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateXamarinSharedModule).GetAssembly());
        }
    }
}