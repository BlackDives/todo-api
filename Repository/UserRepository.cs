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

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }
    }
}
