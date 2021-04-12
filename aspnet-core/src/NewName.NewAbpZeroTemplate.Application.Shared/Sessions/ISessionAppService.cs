using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Sessions.Dto;

namespace NewName.NewAbpZeroTemplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
