using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos
{
    public class CreateOrEditTaskTypeDto : EntityDto<int?>
    {

        [Required]
        public string Name { get; set; }

    }
}