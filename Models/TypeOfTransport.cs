namespace Rezervation.Models
{
    public class TypeOfTransport : BaseModel
    {
        public ICollection<Trip> Trips { get; set; }
    }
}