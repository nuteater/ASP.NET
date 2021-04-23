
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTasks_UserDto : EntityDto<int?>
    {

		 public long? UserId { get; set; }
		 
		 		 public int? TTTaskId { get; set; }
		 
		 
    }
}