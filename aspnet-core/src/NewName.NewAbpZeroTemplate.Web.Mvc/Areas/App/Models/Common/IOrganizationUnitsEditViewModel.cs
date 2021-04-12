using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Organizations.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}