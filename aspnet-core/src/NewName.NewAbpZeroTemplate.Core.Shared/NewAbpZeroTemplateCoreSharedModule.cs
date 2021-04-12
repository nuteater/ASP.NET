using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    public class NewAbpZeroTemplateCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateCoreSharedModule).GetAssembly());
        }
    }
}