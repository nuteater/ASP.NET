using NewName.NewAbpZeroTemplate.Authorization.Users;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[Table("Tasks_Users")]
    public class Tasks_User : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			


		public virtual long? UserId { get; set; }
		
        [ForeignKey("UserId")]
		public User UserFk { get; set; }
		
		public virtual int? TTTaskId { get; set; }
		
        [ForeignKey("TTTaskId")]
		public TTTask TTTaskFk { get; set; }
		
    }
}