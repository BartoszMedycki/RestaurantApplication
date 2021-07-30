using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase
{
   public class RestaurantApplicationDbContext : DbContext
    {
        public RestaurantApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RestarantApplicationDataBase.Entitties.Restaurant> Restaurants { get; set; }
        public DbSet<RestarantApplicationDataBase.Entitties.Dish> Dishes { get; set; }
        public DbSet<RestarantApplicationDataBase.Entitties.Adress> Adresses { get; set; }
      
        
    }
}
