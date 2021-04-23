using Abp.Application.Services.Dto;
using System;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetAllTaskTopicsInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NameFilter { get; set; }



    }
}