using Abp.Application.Services.Dto;
using System;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetAllTask_TaskTopicsInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }


		 public string TaskTopicNameFilter { get; set; }

		 		 public string TTTaskNameFilter { get; set; }

		 
    }
}