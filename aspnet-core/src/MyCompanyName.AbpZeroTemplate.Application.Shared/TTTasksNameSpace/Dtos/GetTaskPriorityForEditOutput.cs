using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTaskPriorityForEditOutput
    {
        public CreateOrEditTaskPriorityDto TaskPriority { get; set; }

    }
}