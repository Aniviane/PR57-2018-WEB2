namespace Food_Delivery_Core.DTO
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public long OrdererId { get; set; }

        public long? DeliveryId { get; set; }

        public long RestorauntId { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public string Comment { get; set; }

        public List<OrderItemDTO> OrderItems { get; set;}
    }
}
