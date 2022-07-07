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

    }
}
