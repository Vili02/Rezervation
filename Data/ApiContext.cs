using Microsoft.EntityFrameworkCore;
using Rezervation.Models;



namespace Rezervation.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Trip>Trips { get; set; }
        public ApiContext(DbContextOptions<ApiContext>options)
            :base




    }
}
