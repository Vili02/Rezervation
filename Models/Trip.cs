namespace Rezervation.Models
{
    public class Trip : BaseModel
    {
        public decimal RunningTime { get; set; }
        public decimal Duration { get; set; }
        public TypeOfTransport TypeOfTransport { get; set; }
        public User User { get; set; }
        public ICollection<Organizer> Organizers { get; set; }
    }
}
