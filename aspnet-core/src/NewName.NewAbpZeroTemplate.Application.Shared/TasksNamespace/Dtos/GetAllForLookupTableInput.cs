using Abp.Application.Services.Dto;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}