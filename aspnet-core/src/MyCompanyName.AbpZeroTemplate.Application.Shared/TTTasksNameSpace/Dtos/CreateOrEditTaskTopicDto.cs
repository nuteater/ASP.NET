using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class CreateOrEditTaskTopicDto : EntityDto<int?>
    {

        public string Name { get; set; }

    }
}