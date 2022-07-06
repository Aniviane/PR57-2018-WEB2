using Food_Delivery_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food_Delivery_Core.Data.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.restoraunt).WithMany(x => x.Menu).HasForeignKey(x => x.RestaurantId);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
