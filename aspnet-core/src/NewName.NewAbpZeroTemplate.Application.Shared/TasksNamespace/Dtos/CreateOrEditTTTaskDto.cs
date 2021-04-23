
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTTTaskDto : EntityDto<int?>
    {

		public string Name { get; set; }
		
		
		public string Description { get; set; }
		
		
		 public int? TaskTypeId { get; set; }
		 
		 		 public int? TaskPriorityId { get; set; }
		 
		 		 public int? SubtasksId { get; set; }
		 
		 		 public int? TaskHistoryId { get; set; }
		 
		 
    }
}