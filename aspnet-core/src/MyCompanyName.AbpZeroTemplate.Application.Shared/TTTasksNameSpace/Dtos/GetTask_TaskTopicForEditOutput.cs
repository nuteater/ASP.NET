using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTask_TaskTopicForEditOutput
    {
        public CreateOrEditTask_TaskTopicDto Task_TaskTopic { get; set; }

        public string TTTaskName { get; set; }

        public string TaskTopicName { get; set; }

    }
}