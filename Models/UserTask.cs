using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_rest_api.Models
{
    public enum UserTaskPriority
    {
        Low, Medium, High
    }

    [Table("todo.user-tasks")]
    public class UserTask
    {
        [Key]
        [Column("task_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("task_name")]  
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("priority")]
        public UserTaskPriority Priority { get; set; }
        [Column("created_at")]
        public DateTime CreatedDate { get; set;}
        [Column("updated_at")]
        public DateTime UpdatedDate { get; set;}
        public ICollection<TaskTag> Tags { get; set; }
    }
}
