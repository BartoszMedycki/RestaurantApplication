using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.Mappers
{
    public class CreateRestaurantDataModelMapper
    {
        IMapper CreateRestaurantMapper;
        public CreateRestaurantDataModelMapper()
        {
            CreateRestaurantMapper = new MapperConfiguration(config => config.CreateMap<DataModels.CreateRestaurantDataModel, Entitties.Restaurant>()
            .ForMember(x => x.Adress, s => s.MapFrom(dto => new Entitties.Adress() { City = dto.City, Street = dto.Street, HomeNumber = dto.HomeNumber })).ReverseMap()).CreateMapper();
                                           
        }

        public Entitties.Restaurant map(DataModels.CreateRestaurantDataModel createRestaurantDataModel)
        {
             return CreateRestaurantMapper.Map<Entitties.Restaurant>(createRestaurantDataModel);
        }
        public DataModels.CreateRestaurantDataModel map(Entitties.Restaurant restaurant)
        {
             return CreateRestaurantMapper.Map<DataModels.CreateRestaurantDataModel>(restaurant);
        }
    }
}
