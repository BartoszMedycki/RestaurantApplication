using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestarantApplicationDataBase.Repositories;
using RestarantApplicationDataBase.Mappers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RestarantApplicationDataBase.DataModels;

namespace RestaurantApplication.Controllers
{
    [Route("Api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IServiceProvider mServiceProvider;
        private readonly RestaurantMapper mRestaurantMapper;
        private readonly CreateRestaurantDataModelMapper mCreateRestaurantDataModelMapper;
        private readonly RestarantApplicationDataBase.RestaurantApplicationDbContext MyDbContext;
        public IRestaurantRepository RestaurantRepository { get; }

        public RestaurantController(IServiceProvider serviceProvider,
            IRestaurantRepository restaurantRepository, RestaurantMapper restaurantMapper, CreateRestaurantDataModelMapper createRestaurantDataModelMapper)
        {
            mServiceProvider = serviceProvider;

            RestaurantRepository = restaurantRepository;

            mRestaurantMapper = restaurantMapper;
            mCreateRestaurantDataModelMapper = createRestaurantDataModelMapper;
            MyDbContext = mServiceProvider.GetService(typeof(RestarantApplicationDataBase.RestaurantApplicationDbContext))
                          as RestarantApplicationDataBase.RestaurantApplicationDbContext;

        }
        [HttpGet]
        public ActionResult<IEnumerable<RestarantApplicationDataBase.Entitties.Restaurant>> getAllRestaurants()
        {

            RestaurantRepository.SaveChanges();

            var result = RestaurantRepository.GetAllRestaurants();
           var a = mRestaurantMapper.Map(result);

            



            return Ok(a);
        }
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDataModel RestaurantDto)
        {
            var restaurant = mCreateRestaurantDataModelMapper.map(RestaurantDto);
            RestaurantRepository.AddRestaurant(restaurant);
            RestaurantRepository.SaveChanges();

            return Created($"/Api/restaurant/{restaurant.Id}",null);
        }

       
    }
}
