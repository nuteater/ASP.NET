
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTaskTopicDto : EntityDto<int?>
    {

		public string Name { get; set; }
		
		

    }
}