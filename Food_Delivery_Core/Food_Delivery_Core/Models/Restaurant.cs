namespace Food_Delivery_Core.Models
{
    public class Restaurant
    {
    
        public long Id { get; set; }
        public string RestName { get; set; }

        public int Stars { get; set; }

        public List<Dish> Menu { get; set; }


    }
}
