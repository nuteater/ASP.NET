using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetAllTTTasksInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string DiscriptionFilter { get; set; }

        public string TaskTypeNameFilter { get; set; }

        public string TaskPriorityNameFilter { get; set; }

        public string SubtaskDescriptionFilter { get; set; }

        public string TaskHistoryDescriptionFilter { get; set; }

    }
}