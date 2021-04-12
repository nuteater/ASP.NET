using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Editions.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}