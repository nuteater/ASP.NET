using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos
{
    public class GetTaskTypeForEditOutput
    {
        public CreateOrEditTaskTypeDto TaskType { get; set; }

    }
}