using BlazorWASM.Server.DB.Alerts;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASM.Server.DB.Users
{
    public class UserContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users { get; set; }

        public UserContext(
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
            modelBuilder.Entity<User>()
                .ToContainer("Users")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Location);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Alerts);
        }
    }
}
