using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Services.Interfaces
{
    public interface IOrderInterface
    {
        List<OrderDTO> GetOrders();
        OrderDTO GetById(long id);

        OrderDTO AddOrder(OrderDTO Order);


        void DeleteOrder(long Id);
    }
}
