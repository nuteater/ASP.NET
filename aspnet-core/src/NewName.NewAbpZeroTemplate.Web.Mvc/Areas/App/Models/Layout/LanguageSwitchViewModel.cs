using System.Collections.Generic;
using Abp.Localization;

namespace NewName.NewAbpZeroTemplate.Web.Areas.App.Models.Layout
{
    public class LanguageSwitchViewModel
    {
        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public LanguageInfo CurrentLanguage { get; set; }
        
        public string CssClass { get; set; }
    }
}
