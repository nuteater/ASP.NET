using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NewName.NewAbpZeroTemplate.Localization
{
    public static class NewAbpZeroTemplateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    NewAbpZeroTemplateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(NewAbpZeroTemplateLocalizationConfigurer).GetAssembly(),
                        "NewName.NewAbpZeroTemplate.Localization.NewAbpZeroTemplate"
                    )
                )
            );
        }
    }
}