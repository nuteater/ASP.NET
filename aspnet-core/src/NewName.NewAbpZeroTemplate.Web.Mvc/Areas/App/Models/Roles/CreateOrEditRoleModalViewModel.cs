using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Authorization.Roles.Dto;
using NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Common;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}