using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Users.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}