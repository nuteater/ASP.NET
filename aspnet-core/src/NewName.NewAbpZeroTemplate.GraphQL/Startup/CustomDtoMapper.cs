using AutoMapper;
using NewName.NewAbpZeroTemplate.Authorization.Users;
using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Startup
{
    public static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserDto>()
                .ForMember(dto => dto.Roles, options => options.Ignore())
                .ForMember(dto => dto.OrganizationUnits, options => options.Ignore());
        }
    }
}