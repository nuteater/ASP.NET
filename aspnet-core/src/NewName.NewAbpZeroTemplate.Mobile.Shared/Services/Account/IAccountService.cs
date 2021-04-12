using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.ApiClient.Models;

namespace NewName.NewAbpZeroTemplate.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        
        Task LoginUserAsync();

        Task LogoutAsync();
    }
}
