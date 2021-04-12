using Abp.Dependency;
using NewName.NewAbpZeroTemplate.Configuration;
using NewName.NewAbpZeroTemplate.Url;
using NewName.NewAbpZeroTemplate.Web.Url;

namespace NewName.NewAbpZeroTemplate.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}