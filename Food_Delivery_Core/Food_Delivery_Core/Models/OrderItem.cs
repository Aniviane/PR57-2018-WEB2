using Food_Delivery_Core.DTO;

namespace Food_Delivery_Core.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public long OrderId { get; set; }

        public string DishComment { get; set; }
        public Dish FoodItem { get; set; }

        public Order Order { get; set; }

        public OrderItem() 
            {


            }
        
        public OrderItem(OrderItemDTO dto)
        {
            Id = 0;
            DishId = dto.DishId;
            OrderId = dto.OrderId;
            DishComment = dto.DishComment;

        }
       
    }
}
