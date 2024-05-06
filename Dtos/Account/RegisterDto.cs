using System.ComponentModel.DataAnnotations;

namespace todo_rest_api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get;}
        [Required]
        public string? Password { get; set; }   
    }
}
