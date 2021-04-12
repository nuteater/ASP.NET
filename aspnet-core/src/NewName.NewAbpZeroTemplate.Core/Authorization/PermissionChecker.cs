using Abp.Authorization;
using NewName.NewAbpZeroTemplate.Authorization.Roles;
using NewName.NewAbpZeroTemplate.Authorization.Users;

namespace NewName.NewAbpZeroTemplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
