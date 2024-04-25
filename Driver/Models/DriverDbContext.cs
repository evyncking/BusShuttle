using Microsoft.EntityFrameworkCore;
using Driver.Models;

namespace Driver.Models
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
        {
        }

        public DbSet<BusNumber> BusNumbers { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Loop> Loops { get; set; }
        public DbSet<DriverModel> Drivers { get; set; }
    }
}
