using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos
{
    public class GetAllTaskTypesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}