namespace Food_Delivery_Core.DTO
{
    public class OrderItemDTO
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public long OrderId { get; set; }

        public string DishComment { get; set; }
    }
}
