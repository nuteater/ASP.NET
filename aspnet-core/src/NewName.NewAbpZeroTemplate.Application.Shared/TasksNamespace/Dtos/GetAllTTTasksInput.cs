using Abp.Application.Services.Dto;
using System;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetAllTTTasksInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }

		public string DescriptionFilter { get; set; }


		 public string TaskTypeNameFilter { get; set; }

		 		 public string TaskPriorityNameFilter { get; set; }

		 		 public string SubtasksDescriptionFilter { get; set; }

		 		 public string TaskHistoryDescriptionFilter { get; set; }

		 
    }
}