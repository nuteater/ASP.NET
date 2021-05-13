using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class CreateOrEditTasks_UserDto : EntityDto<int?>
    {

        public int? TTTaskId { get; set; }

        public long? UserId { get; set; }

    }
}