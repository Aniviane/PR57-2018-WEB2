namespace Food_Delivery_Core.Models
{
    public class Dish
    {
        public long Id { get; set; }
        public string DishName { get; set; }

        public  int Price { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant restoraunt { get; set; }
      
        
    }
}
