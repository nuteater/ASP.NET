using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Localization.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}