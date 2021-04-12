﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout;
using NewName.NewAbpZeroTemplate.Web.Session;
using NewName.NewAbpZeroTemplate.Web.Views;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Views.Shared.Themes.Theme5.Components.AppTheme5Footer
{
    public class AppTheme5FooterViewComponent : NewAbpZeroTemplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme5FooterViewComponent(IPerRequestSessionCache sessionCache)
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
