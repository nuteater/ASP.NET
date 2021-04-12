using Abp.AspNetCore.Mvc.Views;

namespace NewName.NewAbpZeroTemplate.Web.Views
{
    public abstract class NewAbpZeroTemplateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected NewAbpZeroTemplateRazorPage()
        {
            LocalizationSourceName = NewAbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}
