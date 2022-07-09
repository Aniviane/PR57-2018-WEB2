namespace Food_Delivery_Core.DTO
{
    public class RestaurantDTO
    {
        public string RestName { get; set; }

        public int Stars { get; set; }

        public List<DishDTO> Dishes { get; set; }
    }
}
