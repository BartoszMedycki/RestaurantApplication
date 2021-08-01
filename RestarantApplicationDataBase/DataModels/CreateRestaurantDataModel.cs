using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.DataModels
{
  public  class CreateRestaurantDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }

    }
}
