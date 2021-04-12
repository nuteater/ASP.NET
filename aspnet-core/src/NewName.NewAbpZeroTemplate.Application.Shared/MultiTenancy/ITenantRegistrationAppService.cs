using System.Threading.Tasks;
using Abp.Application.Services;
using NewName.NewAbpZeroTemplate.Editions.Dto;
using NewName.NewAbpZeroTemplate.MultiTenancy.Dto;

namespace NewName.NewAbpZeroTemplate.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}