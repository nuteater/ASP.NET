using System.Globalization;

namespace NewName.NewAbpZeroTemplate.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}