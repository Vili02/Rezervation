namespace Rezervation.Models
{
    public class Organizer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Info { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}

