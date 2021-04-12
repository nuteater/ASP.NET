using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace NewName.NewAbpZeroTemplate.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
