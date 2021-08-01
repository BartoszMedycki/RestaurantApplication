using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.Mappers
{
    class DishMapper
    {
        IMapper  mDishMapper;
        public DishMapper()
        {
            mDishMapper = new MapperConfiguration(config => config.CreateMap<Entitties.Dish, DataModels.DishDataModel>().ReverseMap()).CreateMapper();
        }
        public DataModels.DishDataModel map(Entitties.Dish dish)
        {
            return mDishMapper.Map<DataModels.DishDataModel>(dish);
        }
    }
}
