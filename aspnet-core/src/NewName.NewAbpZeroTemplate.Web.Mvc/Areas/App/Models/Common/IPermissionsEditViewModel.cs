using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Permissions.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}