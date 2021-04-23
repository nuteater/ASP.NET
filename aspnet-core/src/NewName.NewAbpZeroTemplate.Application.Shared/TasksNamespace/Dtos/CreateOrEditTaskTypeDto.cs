
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTaskTypeDto : EntityDto<int?>
    {

		public string Name { get; set; }
		
		

    }
}