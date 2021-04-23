using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using NewName.NewAbpZeroTemplate.TasksNamespace;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace NewName.NewAbpZeroTemplate.TasksNamespace
{
	[Table("TTTasks")]
	public class TTTask : Entity, IMayHaveTenant
	{
		public int? TenantId { get; set; }


		public virtual string Name { get; set; }

		public virtual string Description { get; set; }


		public virtual int? TaskTypeId { get; set; }

		[ForeignKey("TaskTypeId")] public TaskType TaskTypeFk { get; set; }

		public virtual int? TaskPriorityId { get; set; }

		[ForeignKey("TaskPriorityId")] public TaskPriority TaskPriorityFk { get; set; }

		public virtual int? SubtasksId { get; set; }

		[ForeignKey("SubtasksId")] public Subtasks SubtasksFk { get; set; }

		public virtual int? TaskHistoryId { get; set; }

		[ForeignKey("TaskHistoryId")] public TaskHistory TaskHistoryFk { get; set; }
	}
}