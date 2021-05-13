using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}