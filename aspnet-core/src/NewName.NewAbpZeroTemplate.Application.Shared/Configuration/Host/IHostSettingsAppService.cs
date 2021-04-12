using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Configuration.Host.Dto;

namespace NewName.NewAbpZeroTemplate.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
