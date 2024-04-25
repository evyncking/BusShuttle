using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerDashboard.Models
{
    public class BusShuttleContext : DbContext
    {
        public BusShuttleContext(DbContextOptions<BusShuttleContext> options) : base(options)
        {
        }

        public DbSet<BusModel> Buses { get; set; }
        public DbSet<DriverModel> Drivers { get; set; }
        public DbSet<LoopModel> Loops { get; set; }
        public DbSet<StopModel> Stops { get; set; }
        public DbSet<RouteModel> Routes { get; set; }
        // public DbSet<EntryModel> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DriverModel
            modelBuilder.Entity<DriverModel>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<DriverModel>()
                .Property(d => d.FirstName)
                .IsRequired();
            modelBuilder.Entity<DriverModel>()
                .Property(d => d.LastName)
                .IsRequired();
            modelBuilder.Entity<DriverModel>()
                .Property(d => d.Username)
                .IsRequired();
            modelBuilder.Entity<DriverModel>()
                .Property(d => d.Password)
                .IsRequired();

            // Configure BusModel
            modelBuilder.Entity<BusModel>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<BusModel>()
                .Property(b => b.BusNumber)
                .IsRequired();

            // Configure LoopModel
            modelBuilder.Entity<LoopModel>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<LoopModel>()
                .Property(l => l.LoopName)
                .IsRequired();

            // Configure StopModel
            modelBuilder.Entity<StopModel>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<StopModel>()
                .Property(s => s.StopName)
                .IsRequired();

            // Configure RouteModel
            modelBuilder.Entity<RouteModel>()
                .HasKey(r => r.Id);
        
            modelBuilder.Entity<RouteModel>()
                .HasOne(r => r.Loop)
                .WithMany()
                .HasForeignKey(r => r.LoopId);

            modelBuilder.Entity<RouteModel>()
                .HasOne(r => r.Stop)
                .WithMany()
                .HasForeignKey(r => r.StopId);

            // modelBuilder.Entity<RouteModel>()
            //     .Ignore(r => r.LoopName);  // Ignore LoopName in RouteModel

            // modelBuilder.Entity<RouteModel>()
            //     .Ignore(r => r.StopName);  // Ignore StopName in RouteModel

            // Configure EntryModel
            // modelBuilder.Entity<EntryModel>()
            //     .HasKey(e => e.Id);
            // modelBuilder.Entity<EntryModel>()
            //     .HasOne(e => e.Stop)
            //     .WithMany()
            //     .HasForeignKey(e => e.StopId);

            // Add more configurations as needed

            // Call base method to apply configurations from other sources
            base.OnModelCreating(modelBuilder);
        }

    }
}
