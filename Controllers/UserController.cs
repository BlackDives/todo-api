using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;

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
            public IActionResult GetUsers()
        {
            var users = _userRepostitory.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
    }
}
