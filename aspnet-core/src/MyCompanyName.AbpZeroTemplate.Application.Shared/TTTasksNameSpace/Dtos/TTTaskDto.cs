using System;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class TTTaskDto : EntityDto
    {
        public string Name { get; set; }

        public string Discription { get; set; }

        public int? TaskTypeId { get; set; }

        public int? TaskPriorityId { get; set; }

        public int? SubtaskId { get; set; }

        public int? TaskHistoryId { get; set; }

    }
}