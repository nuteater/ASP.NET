using System.Collections.Generic;
using MvvmHelpers;
using NewName.NewAbpZeroTemplate.Models.NavigationMenu;

namespace NewName.NewAbpZeroTemplate.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}