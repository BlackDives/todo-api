using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Data;
using todo_rest_api.Dtos.Resources;
using todo_rest_api.Extensions;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;
using todo_rest_api.Services;

namespace todo_rest_api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserTaskRepository _userTaskRepository;
        public UserTaskController(UserManager<User> userManager, IUserTaskRepository userTaskRepository)
        {
            _userManager = userManager;
            _userTaskRepository = userTaskRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTasks()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userTasks = await _userTaskRepository.GetUserTasks(appUser);

            return Ok(userTasks);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUserTask([FromBody] UserTaskDto userTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userTask = new UserTask
            {
                UserId = appUser.Id,
                Name = userTaskDto.TaskName,
                Description = userTaskDto.TaskDescription,
                Status = userTaskDto.TaskStatus,
                Priority = (UserTaskPriority)userTaskDto.Priority,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            var result = await _userTaskRepository.CreateUserTask(userTask);
            if (result == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> PatchUserTask([FromRoute] int id, [FromBody] JsonPatchDocument<UserTask> userTaskPatch)
        {
            if (userTaskPatch == null)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var appuser = await _userManager.FindByNameAsync(username);

            var result = await _userTaskRepository.UpdateUserTask(id, userTaskPatch);

            /*
             * Needed to check the model state before saving changes to database 
             */

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserTask([FromRoute] int id)
        {
            var result = await _userTaskRepository.DeleteUserTask(id);
            return Ok(result);
        } 

    }
}
