using Food_Delivery_Core.DTO;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Data;
using Food_Delivery_Core.Services.Interfaces;
using AutoMapper;

namespace Food_Delivery_Core.Services
{
    public class RestaurantService : IRestaurantInterface
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public RestaurantService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public RestaurantDTO AddRestaurant(RestaurantDTO restaurantDTO)
        {
            

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDTO);
                _context.Restoraunts.Add(restaurant);
                _context.SaveChanges();
                var l = restaurant.Id;
                List<DishDTO> dishes = new List<DishDTO>();
                foreach (var v in restaurantDTO.Dishes)
                {
                    Dish d = new Dish(v);
                    d.RestaurantId = l;
                    dishes.Add(_mapper.Map<DishDTO>(d));
                    _context.Dishes.Add(d);

                }
                _context.SaveChanges();

                dbTransaction.Commit();
                var ret = _mapper.Map<RestaurantDTO>(restaurant);
                ret.Dishes = dishes;
                return ret;
            }



        }

        public void DeleteRestaurant(long Id)
        {

           _context.Restoraunts.Remove(_context.Restoraunts.Find(Id));

            return;
        }

        public RestaurantDTO GetById(long id)
        {
            var ret = _mapper.Map<RestaurantDTO>(_context.Restoraunts.Find(id));
            List<Dish> dishes = _context.Dishes.Where(o => o.RestaurantId == id).ToList();
            ret.Dishes = _mapper.Map<List<DishDTO>>(dishes).ToList();

            return ret;
        }

        public List<RestaurantDTO> GetRestaurants()
        {
            List<RestaurantDTO> ret = new List<RestaurantDTO>();

            List<Restaurant> rests = _context.Restoraunts.ToList();

            foreach(var r in rests)
            {

                var rest = _mapper.Map<RestaurantDTO>(r);
                List<Dish> dishes = _context.Dishes.Where(o => o.RestaurantId == r.Id).ToList();
                rest.Dishes = _mapper.Map<List<DishDTO>>(dishes).ToList();
                ret.Add(rest);
            }
            return ret;
        }
    }
}
