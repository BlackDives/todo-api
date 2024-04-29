using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Data;
using todo_rest_api.Models;
using todo_rest_api.Services;

namespace todo_rest_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {

        private readonly TodoDbContext _todoDbContext;
        public UserTaskController(TodoDbContext context)
        {
            _todoDbContext = context;
        }

        [HttpGet("{userId}/tasks")]
        public async Task<ActionResult<List<UserTask>>> GetAll()
        {
            // Console.WriteLine(userId);
            //return UserTaskService.GetAll();
            return await _todoDbContext.UserTasks.ToListAsync();
        }

        //[HttpGet("{id}")]
        //public ActionResult<UserTask> Get(int id)
        //{
        //    var task = UserTaskService.Get(id);

        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    return task;
        //}

    }
}
