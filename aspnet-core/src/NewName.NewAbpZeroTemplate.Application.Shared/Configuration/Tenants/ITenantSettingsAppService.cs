using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Configuration.Tenants.Dto;

namespace NewName.NewAbpZeroTemplate.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
