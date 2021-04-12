using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Dto;
using NewName.NewAbpZeroTemplate.Logging.Dto;

namespace NewName.NewAbpZeroTemplate.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
