namespace Rezervation.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public Role Role { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
