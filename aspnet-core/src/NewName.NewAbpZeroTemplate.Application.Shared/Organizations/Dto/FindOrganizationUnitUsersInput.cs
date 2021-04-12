using NewName.NewAbpZeroTemplate.Dto;

namespace NewName.NewAbpZeroTemplate.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
