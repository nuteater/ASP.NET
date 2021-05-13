using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace.Dtos
{
    public class GetTaskHistoryForEditOutput
    {
        public CreateOrEditTaskHistoryDto TaskHistory { get; set; }

    }
}