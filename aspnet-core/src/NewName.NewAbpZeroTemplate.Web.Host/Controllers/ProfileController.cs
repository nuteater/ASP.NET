using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using NewName.NewAbpZeroTemplate.Authorization.Users.Profile;
using NewName.NewAbpZeroTemplate.Storage;

namespace NewName.NewAbpZeroTemplate.Web.Controllers
{
    [Authorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService) :
            base(tempFileCacheManager, profileAppService)
        {
        }
    }
}