using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class TripCrudDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; }

        [Required]
        [Range (0, 24, ErrorMessage = "Running time must be between 0 and 24 hours long")]
        public decimal RunningTime { get; set; }

        [Required]
        [Range (0, 7, ErrorMessage = "Duration must be between 0 and 7 days long")]
        public decimal Duration { get; set; }

        public int TypeOfTransportId { get; set; }
        public int UserId { get; set; }
    }
}
