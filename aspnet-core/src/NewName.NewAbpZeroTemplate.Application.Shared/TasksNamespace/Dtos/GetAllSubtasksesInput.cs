using Abp.Application.Services.Dto;
using System;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetAllSubtasksesInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string DescriptionFilter { get; set; }



    }
}