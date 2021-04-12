using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.DynamicEntityProperties.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}
