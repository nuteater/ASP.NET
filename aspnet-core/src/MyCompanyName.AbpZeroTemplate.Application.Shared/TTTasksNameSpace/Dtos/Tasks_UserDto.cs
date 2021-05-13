using System;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class Tasks_UserDto : EntityDto
    {

        public int? TTTaskId { get; set; }

        public long? UserId { get; set; }

    }
}