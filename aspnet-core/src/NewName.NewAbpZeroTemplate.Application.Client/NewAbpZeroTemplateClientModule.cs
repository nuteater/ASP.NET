using Abp.Modules;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate
{
    public class NewAbpZeroTemplateClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NewAbpZeroTemplateClientModule).GetAssembly());
        }
    }
}
