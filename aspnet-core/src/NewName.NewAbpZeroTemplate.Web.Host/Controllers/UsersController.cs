using Abp.AspNetCore.Mvc.Authorization;
using NewName.NewAbpZeroTemplate.Authorization;
using NewName.NewAbpZeroTemplate.Storage;
using Abp.BackgroundJobs;

namespace NewName.NewAbpZeroTemplate.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}