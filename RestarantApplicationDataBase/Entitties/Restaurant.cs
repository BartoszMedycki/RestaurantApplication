using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RestarantApplicationDataBase.Entitties
{
    public class Restaurant : IEqualityComparer<Restaurant>
    {
        public Restaurant() 
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool HasDelivery { get; set; }
        public int AdressId { get; set; }

        
        public virtual Adress Adress{ get; set; }
        public virtual  List<Dish> Dishes { get; set; }

        public bool Equals(Restaurant x, Restaurant y)
        {
            if (x.Name == y.Name) return true;
            else return false;
        }



        public int GetHashCode([DisallowNull] Restaurant obj)
        {
            return 1;
        }
    }
}
