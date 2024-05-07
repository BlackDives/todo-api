using System.ComponentModel.DataAnnotations;

namespace todo_rest_api.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}
