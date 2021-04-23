namespace NewName.NewAbpZeroTemplate.TasksNamespace.Dtos
{
    public class GetTTTaskForViewDto
    {
		public TTTaskDto TTTask { get; set; }

		public string TaskTypeName { get; set;}

		public string TaskPriorityName { get; set;}

		public string SubtasksDescription { get; set;}

		public string TaskHistoryDescription { get; set;}


    }
}