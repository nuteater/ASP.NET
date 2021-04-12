using Abp.AutoMapper;
using NewName.NewAbpZeroTemplate.Organizations.Dto;

namespace NewName.NewAbpZeroTemplate.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}