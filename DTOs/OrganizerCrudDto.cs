using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class OrganizerCrudDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Email must be at least 3 characters long")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters long")]
        public string Phonenumber { get; set; }
    }
}
