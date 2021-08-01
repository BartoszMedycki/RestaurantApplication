using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.Mappers
{
  public  class RestaurantMapper 
    {
        IMapper mapper;
        public RestaurantMapper()
        {
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entitties.Restaurant, DataModels.RestaurantDataModel>()
                   .ForMember(x => x.City, c => c.MapFrom(s => s.Adress.City))
                   .ForMember(x => x.HomeNumber, c => c.MapFrom(s => s.Adress.HomeNumber))
                   .ForMember(x => x.Street, c => c.MapFrom(s => s.Adress.Street));

                config.CreateMap<Entitties.Dish, DataModels.DishDataModel>();

            }).CreateMapper();

            ;
        }
        public DataModels.RestaurantDataModel Map(Entitties.Restaurant restaurant)
        {
            
                return mapper.Map<DataModels.RestaurantDataModel>(restaurant);
            
          
          

        }
        public Entitties.Restaurant Map(DataModels.RestaurantDataModel restaurantDataModel)
        {
            return mapper.Map<Entitties.Restaurant>(restaurantDataModel);

        }
        public IEnumerable<DataModels.RestaurantDataModel> Map(IEnumerable<Entitties.Restaurant> restaurants)
        {
            var list = new List<DataModels.RestaurantDataModel>();
            foreach (var item in restaurants)
            {
              list.Add(mapper.Map<DataModels.RestaurantDataModel>(item));

            }
            return list;
            
        }
        public IEnumerable<Entitties.Restaurant> Map(IEnumerable<DataModels.RestaurantDataModel> restaurants)
        {
            var list = new List<Entitties.Restaurant>();
            foreach (var item in restaurants)
            {
              list.Add(mapper.Map<Entitties.Restaurant>(item));

            }
            return list;
            
        }
    }
}

