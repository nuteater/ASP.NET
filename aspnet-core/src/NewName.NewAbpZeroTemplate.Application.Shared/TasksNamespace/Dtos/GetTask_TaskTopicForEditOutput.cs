using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetTask_TaskTopicForEditOutput
    {
		public CreateOrEditTask_TaskTopicDto Task_TaskTopic { get; set; }

		public string TaskTopicName { get; set;}

		public string TTTaskName { get; set;}


    }
}