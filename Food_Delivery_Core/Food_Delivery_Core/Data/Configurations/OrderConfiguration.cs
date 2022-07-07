using Food_Delivery_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Food_Delivery_Core.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Dishes).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Orderer);
            builder.HasOne(x => x.Restoraunt);
            builder.HasOne(x => x.Deliverer);
        }
    }
}
