using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetAllTaskPrioritiesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}