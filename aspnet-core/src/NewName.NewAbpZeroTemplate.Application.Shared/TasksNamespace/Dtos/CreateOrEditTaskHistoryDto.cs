
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class CreateOrEditTaskHistoryDto : EntityDto<int?>
    {

		public string Description { get; set; }
		
		

    }
}