using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
