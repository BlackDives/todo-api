using System.ComponentModel.DataAnnotations;

namespace todo_rest_api.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
