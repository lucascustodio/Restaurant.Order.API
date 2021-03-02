using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Infra.Data.EntityConfiguration.MorningAggregate
{
    public class MorningConfiguration : IEntityTypeConfiguration<Morning>
    {
        public void Configure(EntityTypeBuilder<Morning> builder)
        {
            builder.ToTable("Mornings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DishType).HasConversion(
                 type => type.Id,
                 id => DishType.FromId(id)).IsRequired();
        }
    }
}
