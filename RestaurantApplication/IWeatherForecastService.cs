using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get();
        public IEnumerable<WeatherForecast> Get(int cout,int min, int max);
    }

   
}
