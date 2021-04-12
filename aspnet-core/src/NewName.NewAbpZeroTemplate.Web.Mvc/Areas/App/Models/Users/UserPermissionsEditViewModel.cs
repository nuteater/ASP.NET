using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Authorization.Users;
using NewName.NewAbpZeroTemplate.Authorization.Users.Dto;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}