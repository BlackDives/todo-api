using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_rest_api.Models
{
    public enum UserTaskPriority
    {
        Low, Medium, High
    }
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public UserTaskPriority Priority { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}
        public ICollection<TaskTag> Tags { get; set; }
    }
}
