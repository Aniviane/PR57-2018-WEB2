using Food_Delivery_Core.DTO;

namespace Food_Delivery_Core.Models
{
    public class Dish
    {
        public long Id { get; set; }
        public string DishName { get; set; }

        public int Price { get; set; }

        public long RestaurantId { get; set; }

        public Restaurant restoraunt { get; set; }

        public Dish() { }

        public Dish(DishDTO dto)
        {
            Id = 0;
            DishName = dto.DishName;
            Price = dto.Price;
            RestaurantId = dto.RestaurantId;
            
        }


    
    }
}
