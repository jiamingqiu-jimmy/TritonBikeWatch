using BlazorWASM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASM.Server.DB
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>()
                .ToContainer("Alerts")
                .HasPartitionKey(a => a.Id);

            modelBuilder.Entity<Device>()
                .ToContainer("Devices")
                .HasPartitionKey(d => d.Id);

            modelBuilder.Entity<Location>()
                .ToContainer("Locations")
                .HasPartitionKey(l => l.Id);

            modelBuilder.Entity<User>()
                .ToContainer("Users")
                .HasPartitionKey(u => u.Id);

            // Define relationships here using Fluent API

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.User)
                .WithMany(u => u.Alerts)
                .HasForeignKey(a => a.UserId); // Assuming you have a UserId property in Alert

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Device)
                .WithMany(d => d.Alerts)
                .HasForeignKey(a => a.DeviceId); // Assuming you have a DeviceId property in Alert

            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Alerts)
                .HasForeignKey(a => a.LocationId); // Assuming you have a LocationId property in Alert

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Location)
                .WithMany(l => l.Devices)
                .HasForeignKey(d => d.LocationId); // Assuming you have a LocationId property in Device

            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LocationId); // Assuming you have a LocationId property in User
        }
    }
}
