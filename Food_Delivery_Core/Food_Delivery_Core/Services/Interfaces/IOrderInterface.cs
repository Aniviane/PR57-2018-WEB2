using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Services.Interfaces
{
    public interface IOrderInterface
    {
        List<OrderDTO> GetOrders();
        List<OrderDTO> GetById(long id);

        OrderDTO AddOrder(OrderDTO Order);

        void UpdateOrder(UpdateOrderDTO dto);

        void DeleteOrder(long Id);
    }
}
