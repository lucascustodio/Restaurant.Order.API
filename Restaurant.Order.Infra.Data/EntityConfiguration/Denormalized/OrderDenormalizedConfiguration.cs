using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Order.Infra.Data.Model.Denormalized;

namespace Restaurant.Order.Infra.Data.EntityConfiguration.Denormalized
{
    public class OrderDenormalizedConfiguration : IEntityTypeConfiguration<OrderDenormalized>
    {
        public void Configure(EntityTypeBuilder<OrderDenormalized> builder)
        {
            builder.ToTable("OrderDenormalized");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Dishes).HasMaxLength(255).IsRequired();
            builder.HasOne(x => x.Order);
        }
    }
}
