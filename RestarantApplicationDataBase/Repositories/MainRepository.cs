using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RestarantApplicationDataBase.Repositories
{
    public abstract class MainRepository<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;
        protected readonly RestaurantApplicationDbContext dbContext;
       public abstract DbSet<T> DbSet { get;}
        public MainRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            dbContext = _serviceProvider.GetService(typeof(RestaurantApplicationDbContext)) as RestaurantApplicationDbContext;

        }
        public IEnumerable<T> GetAll()
        {
            var Records = DbSet;
            List<T> RecordsList = new List<T>();
            foreach (var item in Records)
            {
                RecordsList.Add(item);
            }
            return RecordsList;
        }
        
        
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
