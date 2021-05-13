using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTasks_UserForEditOutput
    {
        public CreateOrEditTasks_UserDto Tasks_User { get; set; }

        public string TTTaskName { get; set; }

        public string UserName { get; set; }

    }
}