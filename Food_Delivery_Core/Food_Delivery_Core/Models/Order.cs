using Food_Delivery_Core.DTO;

namespace Food_Delivery_Core.Models
{
    public class Order
    {

        public long Id { get; set; }

        public List<OrderItem> Dishes { get; set; }


        public long OrdererId { get; set; }

        public long? DeliveryId { get; set; }

        public string Status { get; set; }

        public long RestorauntId { get; set; }

        public DateTime TimeOfOrder { get; set; }



        public string Comment { get; set; }

        public User Orderer { get; set; }

        public User? Deliverer { get; set; }

        public Restaurant Restoraunt { get; set; }


        public Order()
        {

        }

        public Order(OrderDTO dto)
        {
            Id = 0;
            OrdererId = dto.OrdererId;
            Status = "Available";
            RestorauntId = dto.RestorauntId;
            Comment = dto.Comment;
            TimeOfOrder = dto.TimeOfOrder;
            Dishes = new List<OrderItem>();
            foreach(var dtos in dto.OrderItems)
            {
                OrderItem OI = new OrderItem(dtos);
                Dishes.Add(OI);
            }
        }
    }
}
