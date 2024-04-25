using Microsoft.EntityFrameworkCore;
using ManagerDashboard.Models;

namespace Driver.Models
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
        {
        }

        public DbSet<DriverModel> Drivers { get; set; }
    }
}
