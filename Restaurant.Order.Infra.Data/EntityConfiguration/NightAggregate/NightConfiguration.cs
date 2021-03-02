using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Infra.Data.EntityConfiguration.NightAggregate
{
    public class MorningConfiguration : IEntityTypeConfiguration<Night>
    {
        public void Configure(EntityTypeBuilder<Night> builder)
        {
            builder.ToTable("Nights");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DishType).HasConversion(
                 type => type.Id,
                 id => DishType.FromId(id)).IsRequired();
        }
    }
}
