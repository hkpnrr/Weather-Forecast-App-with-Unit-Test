using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.OpenWeatherMap_Model;

namespace WeatherForecastApp.Repositories
{
    public interface IWForecastRepository
    {
        WeatherResponse GetForecast(string city);

    }
}
