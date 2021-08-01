using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.Entitties
{
    public class Dish
    {
        
        public int Id { get; set; }
      
        public string Name { get; set; }
        public string Descrition  { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; } 
        public virtual Restaurant Restaurant { get; set; }
    }
}
