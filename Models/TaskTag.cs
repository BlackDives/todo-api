namespace todo_rest_api.Models
{
    public class TaskTag
    {
        public int Id { get; set; }
        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
