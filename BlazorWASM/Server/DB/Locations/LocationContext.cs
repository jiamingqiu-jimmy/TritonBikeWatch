using Microsoft.EntityFrameworkCore;

namespace BlazorWASM.Server.DB.Locations
{
    public class LocationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Location> Locations { get; set; }

        public LocationContext(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var endpointUri = _configuration.GetSection("CosmosDB:EndpointUri").Value;
            var primaryKey = _configuration.GetSection("CosmosDbSettings:PrimaryKey").Value;
            optionsBuilder.UseCosmos(endpointUri, primaryKey, databaseName: "Core");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .ToContainer("Locations")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
            modelBuilder.Entity<Location>()
                .HasMany(u => u.Alerts);
            modelBuilder.Entity<Location>()
                .HasMany(u => u.Users);
            modelBuilder.Entity<Location>()
                .HasMany(u => u.Devices);
        }
    }
}
