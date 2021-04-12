using System.Threading.Tasks;
using NewName.NewAbpZeroTemplate.Sessions.Dto;

namespace NewName.NewAbpZeroTemplate.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
