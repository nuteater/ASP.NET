using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Delegation;
using NewName.NewAbpZeroTemplate.Authorization.Users.Delegation.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
