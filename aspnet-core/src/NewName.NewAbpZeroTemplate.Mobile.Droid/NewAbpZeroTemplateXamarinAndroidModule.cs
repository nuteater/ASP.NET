using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    [DependsOn(typeof(NewAbpZeroTemplateXamarinSharedModule))]
    public class NewAbpZeroTemplateXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateXamarinAndroidModule).GetAssembly());
        }
    }
}