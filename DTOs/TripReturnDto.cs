using Rezervation.Models;

namespace Rezervation.DTOs
{
    public class TripReturnDto
    {
        public string Name { get; set; }
        public decimal RunningTime { get; set; }
        public decimal Duration { get; set; }
        public TypeOfTransport TypeOfTransport { get; set; }
        public UserReturnDto User { get; set; }
    }
}
