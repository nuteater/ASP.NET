using Abp.Application.Services.Dto;
using System;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetAllTaskHistoriesForExcelInput
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

    }
}