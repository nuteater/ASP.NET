using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout;
using NewName.NewAbpZeroTemplate.Web.Session;
using NewName.NewAbpZeroTemplate.Web.Views;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Views.Shared.Themes.Theme9.Components.AppTheme9Footer
{
    public class AppTheme9FooterViewComponent : NewAbpZeroTemplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme9FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
