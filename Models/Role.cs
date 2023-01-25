namespace Rezervation.Models
{
    public class Role : BaseModel
    {
        public ICollection<User> Users { get; set; }
    }
}
