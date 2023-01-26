using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class TypeOfTransportCrudDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }
    }
}
