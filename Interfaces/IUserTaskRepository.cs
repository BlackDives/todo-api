using Microsoft.AspNetCore.JsonPatch;
using todo_rest_api.Dtos.Resources;
using todo_rest_api.Models;

namespace todo_rest_api.Interfaces
{
    public interface IUserTaskRepository
    {
        Task<List<UserTask>> GetUserTasks(User user);

        Task<UserTask> CreateUserTask(UserTask userTask);

        Task<UserTask> UpdateUserTask(int id, JsonPatchDocument<UserTask> userTaskPatch);

        Task<UserTask> DeleteUserTask(int id);
    }
}
