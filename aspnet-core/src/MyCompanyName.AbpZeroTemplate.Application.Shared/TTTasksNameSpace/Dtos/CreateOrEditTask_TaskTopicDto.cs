using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class CreateOrEditTask_TaskTopicDto : EntityDto<int?>
    {

        public int? TTTaskId { get; set; }

        public int? TaskTopicId { get; set; }

    }
}