using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Services.Interfaces
{
    public interface IRestaurantInterface
    {
        List<RestaurantDTO> GetRestaurants();
        RestaurantDTO GetById(long id);

        RestaurantDTO AddRestaurant(RestaurantDTO restaurantDTO);

        void DeleteRestaurant(long Id);
    }
}
