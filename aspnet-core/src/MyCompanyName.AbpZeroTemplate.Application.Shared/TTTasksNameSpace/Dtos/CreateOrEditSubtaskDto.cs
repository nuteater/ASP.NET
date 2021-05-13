using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class CreateOrEditSubtaskDto : EntityDto<int?>
    {

        public string Description { get; set; }

    }
}