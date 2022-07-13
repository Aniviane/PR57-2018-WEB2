using Food_Delivery_Core.DTO;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Data;
using Food_Delivery_Core.Services.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace Food_Delivery_Core.Services
{
    public class OrderService : IOrderInterface
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public OrderDTO AddOrder(OrderDTO Order)
        {

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                Order newOrder = new Order(Order);
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                var l = newOrder.Id;
                List<OrderItemDTO> OIs = new List<OrderItemDTO>();
                foreach (var v in Order.OrderItems)
                {
                    OrderItem oi = new OrderItem(v);
                    oi.OrderId = l;
                    OIs.Add(_mapper.Map<OrderItemDTO>(oi));
                    _context.OrderItems.Add(oi);
                }
                 _context.SaveChangesAsync();

                dbTransaction.Commit();

                var ret = _mapper.Map<OrderDTO>(newOrder);
                ret.OrderItems = OIs;

                return ret;
            }
        }

        public void DeleteOrder(long Id)
        {
            _context.Orders.Remove(_context.Orders.Find(Id));
            return;
        }

        public OrderDTO GetById(long id)
        {
            var ret =_mapper.Map<OrderDTO>(_context.Orders.Find(id));
            List<OrderItem> OIs = _context.OrderItems.Where(o => o.OrderId == id).ToList();
            ret.OrderItems = _mapper.Map<List<OrderItemDTO>>(OIs);
            return ret;
        }

        public List<OrderDTO> GetOrders()
        {
            
            List<Order> orders = _context.Orders.ToList();
            List<OrderDTO> ret = _mapper.Map<List<OrderDTO>>(orders);
            List<OrderItemDTO> ois = _mapper.Map<List<OrderItemDTO>>(_context.OrderItems.ToList());

            foreach (var v in ret)
            {
               List<OrderItemDTO> OIs = ois.Where(o => o.OrderId == v.Id).ToList();
                //if(OIs != null)
                //{
                //    foreach( var e in OIs)
                //    {
                //        if(v.OrderItems.Find( o => o.Id == e.Id) == null)
                //        {
                //            v.OrderItems.Add(e);
                //        }
                //    }
                //}
                v.OrderItems = OIs;
            }

            return ret;

        }
        
        public void UpdateOrder(UpdateOrderDTO dto)
        {
            if (_httpContextAccessor != null)
            {
                long deliveryId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
                if (dto.mode == 1)
                {//Accept Order
                    var order = _context.Orders.Where(o => o.Id == dto.orderId).First();
                    order.DeliveryId = deliveryId;
                    order.Status = "Accepted";
                    _context.SaveChanges();
                }
                else
                {//Finalize order
                    var order = _context.Orders.Where(o => o.Id == dto.orderId).First();
                    order.Status = "Delivered";
                    _context.SaveChanges();
                }

            }
        }
    }
}
