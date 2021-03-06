using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    [Table("TaskHistories")]
    public class TaskHistory : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string Description { get; set; }

    }
}