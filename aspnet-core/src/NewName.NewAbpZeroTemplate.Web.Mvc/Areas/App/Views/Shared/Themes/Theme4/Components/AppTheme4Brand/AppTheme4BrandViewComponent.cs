﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout;
using NewName.NewAbpZeroTemplate.Web.Session;
using NewName.NewAbpZeroTemplate.Web.Views;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Views.Shared.Themes.Theme4.Components.AppTheme4Brand
{
    public class AppTheme4BrandViewComponent : NewAbpZeroTemplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme4BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
