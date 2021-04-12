using Abp.AspNetCore.Mvc.ViewComponents;

namespace NewName.NewAbpZeroTemplate.Web.Views
{
    public abstract class NewAbpZeroTemplateViewComponent : AbpViewComponent
    {
        protected NewAbpZeroTemplateViewComponent()
        {
            LocalizationSourceName = NewAbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}