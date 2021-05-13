using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSace.Dtos
{
    public class GetAllTaskTypesForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}