using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTaskTopicForEditOutput
    {
        public CreateOrEditTaskTopicDto TaskTopic { get; set; }

    }
}