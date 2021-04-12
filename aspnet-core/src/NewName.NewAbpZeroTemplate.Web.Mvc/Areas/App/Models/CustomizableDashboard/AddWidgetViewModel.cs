using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.DashboardCustomization.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
