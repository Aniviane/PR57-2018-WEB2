using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Services.Interfaces
{
    public interface IDishInterface
    {
        List<DishDTO> GetDishes();
        DishDTO GetById(long id);

        DishDTO AddDisht(DishDTO Dish);

        DishDTO UpdateDish(long id, DishDTO Dish);

        void DeleteDish(long Id);
    }
}
