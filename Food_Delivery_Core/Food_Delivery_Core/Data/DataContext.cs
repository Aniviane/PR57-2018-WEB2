using Microsoft.EntityFrameworkCore;
using Food_Delivery_Core.Models;



namespace Food_Delivery_Core.Data
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions<DataContext> _options;

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restoraunts { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            _options = options;
        }

         
    }
}
