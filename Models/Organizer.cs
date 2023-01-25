namespace Rezervation.Models
{
    public class Organizer : BaseModel
    {
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}

