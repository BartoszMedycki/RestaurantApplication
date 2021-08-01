using RestarantApplicationDataBase.Entitties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.DataModels
{
   public class RestaurantDataModel : IEqualityComparer<RestaurantDataModel>
    {
        public RestaurantDataModel()
        {

        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }




        public List<DishDataModel> Dishes { get; set; }

        public bool Equals(RestaurantDataModel x, RestaurantDataModel y)
        {
            if (x.Name == y.Name) return true;
            else return false;
        }

        public int GetHashCode([DisallowNull] RestaurantDataModel obj)
        {
            throw new NotImplementedException();
        }
    }
}

