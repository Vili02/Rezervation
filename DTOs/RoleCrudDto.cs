using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class RoleCrudDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Role name must be at least 3 characters long")]
        public string Name { get; set; }
    }
}
