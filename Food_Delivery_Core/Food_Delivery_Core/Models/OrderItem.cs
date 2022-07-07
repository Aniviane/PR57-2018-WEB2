namespace Food_Delivery_Core.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public long OrderId { get; set; }

        public Dish FoodItem { get; set; }

        public Order Order { get; set; }

       
    }
}
