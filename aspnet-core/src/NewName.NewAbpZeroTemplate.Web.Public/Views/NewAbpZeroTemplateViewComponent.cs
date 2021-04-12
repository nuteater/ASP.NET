using Abp.AspNetCore.Mvc.ViewComponents;

namespace NewName.NewAbpZeroTemplate.Web.Public.Views
{
    public abstract class NewAbpZeroTemplateViewComponent : AbpViewComponent
    {
        protected NewAbpZeroTemplateViewComponent()
        {
            LocalizationSourceName = NewAbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}