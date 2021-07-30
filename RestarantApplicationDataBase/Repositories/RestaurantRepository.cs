using Microsoft.EntityFrameworkCore;
using RestarantApplicationDataBase.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarantApplicationDataBase.Repositories
{
    public class RestaurantRepository : IRestaurantRepository

    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RestaurantApplicationDbContext dbContext;
        private DbSet<Restaurant> DbSet => dbContext.Restaurants;

        public RestaurantRepository(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            dbContext = _serviceProvider.GetService(typeof(RestaurantApplicationDbContext)) as RestaurantApplicationDbContext;

        }

        public void AddRestaurant(Restaurant restaurant)
        {
            var ListOfRestaurants = DbSet.ToList();
            if (!ListOfRestaurants.Contains(restaurant, new Restaurant()))
            {
                DbSet.Add(restaurant);
            }

        }
        public IEnumerable<Entitties.Restaurant> GetAllRestaurants()
        {
            var allRestaurants = new List<Restaurant>();
            var restaurant = DbSet;



            foreach (var item in restaurant)
            {

                allRestaurants.Add(item);
            }
            return allRestaurants;

        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
        public void UpdateRestaurant(int id, Entitties.Restaurant restaurant)
        {
            var restaurantToUpdate = DbSet.Where(RestaurantId => RestaurantId.Id == id).FirstOrDefault();
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.Type = restaurant.Type;
            restaurantToUpdate.HasDelivery = restaurant.HasDelivery;
            restaurantToUpdate.Dishes = restaurant.Dishes;
            restaurantToUpdate.Adress = restaurant.Adress;
            restaurantToUpdate.AdressId = restaurant.AdressId;
        }
        public void RemoveRestaurant(int id)
        {
            var restaurantToRemove = DbSet.Where(RestaurantId => RestaurantId.Id == id).FirstOrDefault();
            DbSet.Remove(restaurantToRemove);
        }





    }
}

