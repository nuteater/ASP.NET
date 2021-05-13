using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class CreateOrEditTaskPriorityDto : EntityDto<int?>
    {

        public string Name { get; set; }

    }
}