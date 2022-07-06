namespace Food_Delivery_Core.Models
{
    public class AvailableOrder
    {
        public long Id  { get; set; }
        public long OrdererId  { get; set; }

        public long RestourantId   { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public List<Dish> Dishes  { get; set; }

        public string Comment  { get; set; }    

        public User Orderer { get; set; }

        public Restaurant Restoraunt { get; set; }


    }
}
