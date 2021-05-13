using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace MyCompanyName.AbpZeroTemplate.TTTasksNameSpace
{
    [Table("Subtasks")]
    public class Subtask : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string Description { get; set; }

    }
}