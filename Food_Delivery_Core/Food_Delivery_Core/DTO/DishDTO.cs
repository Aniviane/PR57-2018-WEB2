namespace Food_Delivery_Core.DTO
{
    public class DishDTO
    {
        public long Id { get; set;  }
        public string DishName { get; set; }

        public int Price { get; set; }

        public long RestaurantId { get; set; }
    }
}
