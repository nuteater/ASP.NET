using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout;
using NewName.NewAbpZeroTemplate.Web.Views;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : NewAbpZeroTemplateViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
