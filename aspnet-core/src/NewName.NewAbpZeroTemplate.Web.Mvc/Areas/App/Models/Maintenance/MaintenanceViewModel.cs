using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Caching.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}