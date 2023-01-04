namespace Rezervation.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RunningTime { get; set; }
        public double Duration { get; set; }
        public int TypeOfTransportId { get; set; }
        public int Organizer { get; set; }
        public int UserId { get; set; }
        public string Info { get; set; }
        public ICollection<Organizer> Organizers { get; set; }
    }
}
