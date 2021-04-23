
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTask_TaskTopicDto : EntityDto<int?>
    {

		 public int? TaskTopicId { get; set; }
		 
		 		 public int? TTTaskId { get; set; }
		 
		 
    }
}