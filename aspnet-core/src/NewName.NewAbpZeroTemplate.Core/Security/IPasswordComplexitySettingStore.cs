using System.Threading.Tasks;

namespace NewName.NewAbpZeroTemplate.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
