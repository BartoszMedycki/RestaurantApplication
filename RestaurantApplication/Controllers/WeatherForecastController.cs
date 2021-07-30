using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestarantApplicationDataBase.Repositories;
using RestarantApplicationDataBase.Entitties;

namespace RestaurantApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;
        private readonly IRestaurantRepository _restaurantRepository;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service,
            IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _service = service;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("/{max}")]
        public IEnumerable<Restaurant> Get()
        {

            _restaurantRepository.AddRestaurant(new Restaurant
            {
                Name = "fsafas",
                HasDelivery = true,
                Type = "fast food",
                Adress = new Adress 
                { 
                City = "Krakow",
                Street = " Florianska",
                HomeNumber = 15
                }
                
                
                
            });
            
            _restaurantRepository.SaveChanges();
            

            var result = _restaurantRepository.GetAllRestaurants();
           
            return result;
        }

        [HttpGet("CurrentDay")]
        public ActionResult<IEnumerable<WeatherForecast>> Get2([FromQuery] int count, [FromBody] MinMaxTemperature minMax)
        {
            
           if (count > 0 && minMax.Min < minMax.Max )
           {
                var result = _service.Get(count, minMax.Min, minMax.Max);
  
                return Ok(result);
            }
            else
            {
               return BadRequest();
            }

        }
    }
}

