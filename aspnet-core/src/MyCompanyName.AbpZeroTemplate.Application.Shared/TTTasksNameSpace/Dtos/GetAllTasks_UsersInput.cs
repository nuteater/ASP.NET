using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetAllTasks_UsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string TTTaskNameFilter { get; set; }

        public string UserNameFilter { get; set; }

    }
}