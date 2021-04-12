using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewName.NewAbpZeroTemplate.Authorization;
using NewName.NewAbpZeroTemplate.DashboardCustomization;
using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Startup;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(NewAbpZeroTemplateDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}