using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.DynamicEntityProperties.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
