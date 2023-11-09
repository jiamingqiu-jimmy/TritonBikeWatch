using Microsoft.EntityFrameworkCore;

namespace BlazorWASM.Server.DB.Devices
{
    public class DeviceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Device> Devices { get; set; }

        public DeviceContext(
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
            modelBuilder.Entity<Device>()
                .ToContainer("Devices")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
            modelBuilder.Entity<Device>()
                .HasOne(u => u.Location);
            modelBuilder.Entity<Device>()
                .HasMany(u => u.Alerts);
        }
    }
}
