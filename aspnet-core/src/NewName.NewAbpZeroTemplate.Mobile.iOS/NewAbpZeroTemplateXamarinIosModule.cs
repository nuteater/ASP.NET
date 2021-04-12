using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    [DependsOn(typeof(NewAbpZeroTemplateXamarinSharedModule))]
    public class NewAbpZeroTemplateXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateXamarinIosModule).GetAssembly());
        }
    }
}