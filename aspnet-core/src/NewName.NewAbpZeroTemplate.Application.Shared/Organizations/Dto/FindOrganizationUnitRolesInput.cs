using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Organizations.Dto
{
    public class FindOrganizationUnitRolesInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}