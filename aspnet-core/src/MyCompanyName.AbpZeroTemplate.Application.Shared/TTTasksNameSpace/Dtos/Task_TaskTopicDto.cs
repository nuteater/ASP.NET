using System;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class Task_TaskTopicDto : EntityDto
    {

        public int? TTTaskId { get; set; }

        public int? TaskTopicId { get; set; }

    }
}