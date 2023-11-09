using BlazorWASM.Server.DB.Locations;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASM.Server.DB.Alerts
{
    public class AlertContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Alert> Alerts { get; set; }

        public AlertContext(
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
            modelBuilder.Entity<Alert>()
                .ToContainer("Alerts")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
            modelBuilder.Entity<Alert>()
                .HasOne(u => u.Location);
            modelBuilder.Entity<Alert>()
                .HasOne(u => u.User);
            modelBuilder.Entity<Alert>()
                .HasOne(u => u.Device);
        }
    }
}
