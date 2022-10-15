using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecyclingPoint.Domain;

namespace RecyclingPoint.Persistence
{
    public class RecPointContext : DbContext
    {
        public DbSet<Position>? Positions { get; set; }
        public DbSet<RecyclableType>? RecyclableTypes { get; set; }
        public DbSet<StorageType>? StorageTypes { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Storage>? Storages { get; set; }
        public DbSet<AcceptedRecyclable>? AcceptedRecyclables { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();
            string connectionString = config.GetConnectionString("SQLConnection");
            _ = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }
    }
}
