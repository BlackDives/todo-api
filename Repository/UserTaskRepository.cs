using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Data;
using todo_rest_api.Dtos.Resources;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;

namespace todo_rest_api.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public UserTaskRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        public async Task<List<UserTask>> GetUserTasks(User user)
        {
            var userTasks = await _todoDbContext.UserTasks.Where(x => x.UserId == user.Id).Select(task => new UserTask
            {
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate,
            }).ToListAsync();

            return userTasks;
        }

        public async Task<UserTask> CreateUserTask(UserTask userTask)
        {
            await _todoDbContext.UserTasks.AddAsync(userTask);
            await _todoDbContext.SaveChangesAsync();

            return userTask;
        }

        public async Task<UserTask> UpdateUserTask(int id, JsonPatchDocument<UserTask> userTaskPatch)
        {
            var taskToUpdate = await _todoDbContext.UserTasks.FindAsync(id);

            userTaskPatch.ApplyTo(taskToUpdate);
            await _todoDbContext.SaveChangesAsync();

            var updatedTask = await _todoDbContext.UserTasks.FindAsync(id);

            return updatedTask;
        }

        public async Task<UserTask> DeleteUserTask(int id)
        {
            var taskToDelete = await _todoDbContext.UserTasks.FindAsync(id);
             _todoDbContext.UserTasks.Remove(taskToDelete);
           await _todoDbContext.SaveChangesAsync();

            return taskToDelete;
        }
    }
}
