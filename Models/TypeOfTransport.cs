namespace Rezervation.Models
{
    public class TypeOfTransport
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}