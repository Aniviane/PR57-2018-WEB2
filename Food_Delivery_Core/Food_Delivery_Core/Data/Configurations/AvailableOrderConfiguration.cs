using Food_Delivery_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Food_Delivery_Core.Data.Configurations
{
    public class AvailableOrderConfiguration : IEntityTypeConfiguration<AvailableOrder>
    {
        public void Configure(EntityTypeBuilder<AvailableOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Orderer);
            builder.HasOne(x => x.Restoraunt);
            builder.HasMany(x => x.Dishes);

        }
    }
}
