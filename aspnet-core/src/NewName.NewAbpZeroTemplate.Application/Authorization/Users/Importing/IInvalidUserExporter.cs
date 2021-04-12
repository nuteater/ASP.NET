using System.Collections.Generic;
using NewName.NewAbpZeroTemplate.Authorization.Users.Importing.Dto;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
