using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetAllTask_TaskTopicsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string TTTaskNameFilter { get; set; }

        public string TaskTopicNameFilter { get; set; }

    }
}