using System.Collections.Generic;
using Abp.Localization;
using NewName.NewAbpZeroTemplate.Install.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
