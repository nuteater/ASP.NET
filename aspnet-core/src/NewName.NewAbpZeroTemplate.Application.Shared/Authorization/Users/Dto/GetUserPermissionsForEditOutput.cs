using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Permissions.Dto;

namespace NewName.NewAbpZeroTemplate.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}