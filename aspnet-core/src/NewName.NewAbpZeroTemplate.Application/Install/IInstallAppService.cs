using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Install.Dto;

namespace NewName.NewAbpZeroTemplate.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}