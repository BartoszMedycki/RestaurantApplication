using RestarantApplicationDataBase.Entitties;
using System.Collections.Generic;

namespace RestarantApplicationDataBase.Repositories
{
    public interface IRestaurantRepository
    {
        void AddRestaurant(Restaurant restaurant);
        IEnumerable<Restaurant> GetAllRestaurants();
        void RemoveRestaurant(int id);
        void UpdateRestaurant(int id, Restaurant restaurant);
        void SaveChanges();
        public IEnumerable<Restaurant> GetAll();
    }
}