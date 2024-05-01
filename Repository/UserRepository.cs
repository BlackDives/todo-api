using todo_rest_api.Data;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;

namespace todo_rest_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _context;
        public UserRepository(TodoDbContext context) 
        { 
            _context = context; 
        }

        public User GetUserById(int id)
        {
           return _context.Users.Find(id);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public UserTask GetUserTask(int id, int taskId)
        {
            return _context.UserTasks.SingleOrDefault(x => x.UserId == id && x.Id == taskId);
        }

        public ICollection<UserTask> GetUserTasks(int userId)
        {
            return _context.UserTasks.Where(x => x.UserId == userId).ToList();
        }
    }
}
