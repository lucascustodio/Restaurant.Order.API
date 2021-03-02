using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Core;
using Restaurant.Order.Infra.Data.Model.Denormalized;

namespace Restaurant.Order.Infra.Data
{
    public class Context : DbContext
    {
        public static readonly string SCHEMA = "restaurantorder";
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);

            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Enumeration>();

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Morning> Mornings { get; set; }
        public DbSet<Night> Nights { get; set; }
        public DbSet<Domain.Aggregates.OrderAggregate.Order> Orders { get; set; }
        public DbSet<OrderDenormalized> OrderDenormalizeds { get; set; }

    }

    public class ContextDesignFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Restaurant;Trusted_Connection=True;");

            return new Context(optionsBuilder.Options);
        }
    }
}
