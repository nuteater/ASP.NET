using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Permissions.Dto;

namespace NewName.NewAbpZeroTemplate.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}