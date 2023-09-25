using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class UserViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}