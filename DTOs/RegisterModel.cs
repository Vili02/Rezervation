using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class RegisterModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long")]
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters long")]
        public string Phonenumber { get; set; }
    }
}
