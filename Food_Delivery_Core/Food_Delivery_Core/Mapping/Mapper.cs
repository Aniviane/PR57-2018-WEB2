using AutoMapper;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Mapping
{
    public class FoodMapper : Profile
    {
        public FoodMapper()
        {
            CreateMap<RegisterDTO, User>().ReverseMap();
            CreateMap<DishDTO, Dish>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<RestaurantDTO, Restaurant>().ReverseMap();
           
        }


    }
}
