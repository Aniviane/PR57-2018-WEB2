using Food_Delivery_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Food_Delivery_Core.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>

    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Order).WithMany(x => x.Dishes).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.FoodItem);
        }
    }
}
