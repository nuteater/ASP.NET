﻿using Abp.Auditing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace NewName.NewAbpZeroTemplate.Web.Controllers
{
    public class HomeController : NewAbpZeroTemplateControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [DisableAuditing]
        public IActionResult Index()
        {
            if (_webHostEnvironment.IsDevelopment())
            {
                return RedirectToAction("Index", "Ui");
            }

            return Redirect("/index.html");
        }
    }
}
