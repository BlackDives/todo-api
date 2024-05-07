using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using todo_rest_api.Dtos.Account;
using todo_rest_api.Interfaces;
using todo_rest_api.Models;
using todo_rest_api.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace todo_rest_api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.EmailAddress,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Password = registerDto.Password,
                    PhoneNumber = registerDto.PhoneNumber,
                    ProfilePictureUrl = registerDto.ProfilePictureUrl,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }  catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
