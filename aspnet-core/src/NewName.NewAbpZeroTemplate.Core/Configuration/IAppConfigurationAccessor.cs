using Microsoft.Extensions.Configuration;

namespace NewName.NewAbpZeroTemplate.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
