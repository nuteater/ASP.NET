using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace NewName.NewAbpZeroTemplate.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
