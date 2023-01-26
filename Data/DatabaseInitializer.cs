using Rezervation.Models;

namespace Rezervation.Data
{
    public static class DatabaseInitializer
    {
        public static void SeedAdminInDatabase(ApiContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(
                new User
                {
                    Name = "Veli",
                    Username = "Admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    Phonenumber = "0000000000",
                    Role = context.Roles.First(r => r.Name == "Admin")
                });
            context.SaveChanges();
        }
        public static void SeedRolesInDatabase(ApiContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            context.Roles.AddRange(
                new Role 
                { 
                    Name = "Admin" 
                },
                new Role
                {
                    Name = "User"
                });
            context.SaveChanges();
        }
    }
}
