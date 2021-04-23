using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[Table("Task_TaskTopics")]
    public class Task_TaskTopic : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			


		public virtual int? TaskTopicId { get; set; }
		
        [ForeignKey("TaskTopicId")]
		public TaskTopic TaskTopicFk { get; set; }
		
		public virtual int? TTTaskId { get; set; }
		
        [ForeignKey("TTTaskId")]
		public TTTask TTTaskFk { get; set; }
		
    }
}