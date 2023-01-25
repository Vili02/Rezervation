using Microsoft.EntityFrameworkCore;
using Rezervation.Models;



namespace Rezervation.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext>options)
            : base(options)
        { 
        }

        public DbSet<Trip>Trips { get; set; }

        public DbSet<Role>Roles { get; set;}

        public DbSet<Organizer>Organizers { get; set;}

        public DbSet<User>Users { get; set;}

        public DbSet<TypeOfTransport> TypeOfTransports { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
