using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Repositories
{
    public static class CityNameRepository
    {
        public static List<string> _favCities = null;

        static CityNameRepository()
        {
            _favCities = new List<string>
            {
                new string("london"),   
                new string("kocaeli"),
                new string("istanbul"),
                new string("ankara"),





            };

        }

        public static void AddCity(string cityName)
        {
            if (!_favCities.Contains(cityName.ToLower()))
            {
                _favCities.Add(cityName);
            }
        }
    }
}
