using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Infra.Data.EntityConfiguration.OrdersAggregate
{
    public class MenuConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderAggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.OrderAggregate.Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DishTypes).IsRequired();

            builder.Property(x => x.PeriodType).HasConversion(
                    type => type.Id,
                    id => PeriodType.FromId(id)).IsRequired();
        }
    }
}
