namespace Rezervation.DTOs
{
    public class UserReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public RoleReturnDto Role { get; set; }
    }
}
