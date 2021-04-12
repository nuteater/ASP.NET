using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace NewName.NewAbpZeroTemplate.Web.Public.Views
{
    public abstract class NewAbpZeroTemplateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected NewAbpZeroTemplateRazorPage()
        {
            LocalizationSourceName = NewAbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}
