namespace Rezervation.DTOs
{
    public class UserReturnDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public RoleReturnDto Role { get; set; }
    }
}
