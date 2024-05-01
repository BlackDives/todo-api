using todo_rest_api.Models;

namespace todo_rest_api.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();

        ICollection<UserTask> GetUserTasks(int userId);

        User GetUserById(int id);

        UserTask GetUserTask(int userId, int taskId);
    }
}
