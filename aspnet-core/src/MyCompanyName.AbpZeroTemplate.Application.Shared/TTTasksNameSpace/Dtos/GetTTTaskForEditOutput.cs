using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTTTaskForEditOutput
    {
        public CreateOrEditTTTaskDto TTTask { get; set; }

        public string TaskTypeName { get; set; }

        public string TaskPriorityName { get; set; }

        public string SubtaskDescription { get; set; }

        public string TaskHistoryDescription { get; set; }

    }
}