namespace todo_rest_api.Dtos.Resources
{
    public class UserTaskDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public int Priority { get; set; }
    }
}
