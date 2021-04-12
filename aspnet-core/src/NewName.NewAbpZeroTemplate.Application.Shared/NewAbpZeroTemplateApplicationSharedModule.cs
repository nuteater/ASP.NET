using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    [DependsOn(typeof(NewAbpZeroTemplateCoreSharedModule))]
    public class NewAbpZeroTemplateApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateApplicationSharedModule).GetAssembly());
        }
    }
}