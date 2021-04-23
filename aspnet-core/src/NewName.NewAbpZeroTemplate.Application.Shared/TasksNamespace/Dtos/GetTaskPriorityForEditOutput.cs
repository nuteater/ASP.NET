using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetTaskPriorityForEditOutput
    {
		public CreateOrEditTaskPriorityDto TaskPriority { get; set; }


    }
}