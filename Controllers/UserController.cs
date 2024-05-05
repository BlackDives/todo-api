using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;
using todo_rest_api.Repository;

namespace todo_rest_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepostitory;
        public UserController(IUserRepository userRepository)
        {
            _userRepostitory = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userRepostitory.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _userRepostitory.GetUserById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("{id}/tasks")]
        public IActionResult GetUserTasks([FromRoute] int id) 
        { 
            var tasks = _userRepostitory.GetUserTasks(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tasks);
        }

        [HttpGet("{id}/tasks/{taskId}")]
        public IActionResult GetTask([FromRoute] int id, [FromRoute] int taskId)
        {
            var tasks = _userRepostitory.GetUserTask(id, taskId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            _userRepostitory.CreateUser(user);
            return CreatedAtAction(nameof(PostUser), new {id = user.Id}, user);
        }

        [HttpPost("{id}/tasks")]
        public IActionResult PostUserTask([FromBody] UserTask userTask)
        {
            _userRepostitory.CreateUserTask(userTask);
            return CreatedAtAction(nameof(PostUserTask), new {id = userTask.Id}, userTask);
        }
    }
}
