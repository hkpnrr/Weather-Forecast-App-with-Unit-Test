using LiteDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using WeatherForecastApp.OpenWeatherMap_Model;
using WeatherForecastApp.Repositories;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;

        public WeatherForecastController(IWForecastRepository WForecastRepository)
        {
            _WForecastRepository = WForecastRepository;

        }
        [HttpGet]
        public IActionResult SearchByCity(SearchByCity cityModel)
        {
            var viewModel = new SearchByCity();
            viewModel.favCities = new List<City>();

            foreach (var item in CityNameRepository._favCities)
            {
                var tempCity = new City();
                

                WeatherResponse weatherResponse = _WForecastRepository.GetForecast(item);
                
                if (weatherResponse != null)
                {
                    tempCity.Name = weatherResponse.Name;
                    tempCity.Temperature = weatherResponse.Main.Temp;
                    tempCity.Humidity = weatherResponse.Main.Humidity;
                    tempCity.Pressure = weatherResponse.Main.Pressure;
                    tempCity.Weather = weatherResponse.Weather[0].Main;
                    tempCity.Wind = weatherResponse.Wind.Speed;

                    viewModel.favCities.Add(tempCity);
                }

                
            }


            

            
            return View(viewModel);

        }
        [HttpPost]
        [ActionName("SearchByCity")]
        public IActionResult SearchByCityy(SearchByCity model)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = model.CityName });
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
            City viewModel = new City();
            if(weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature = weatherResponse.Main.Temp;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult AddFavCity()
        {


            return View();
        }
        [HttpPost]
        public IActionResult AddFavCity(string favCityName)
        {

            CityNameRepository.AddCity(favCityName);

            var viewModel = new SearchByCity();
            viewModel.favCities = new List<City>();

            foreach (var item in CityNameRepository._favCities)
            {
                var tempCity = new City();


                WeatherResponse weatherResponse = _WForecastRepository.GetForecast(item);

                if (weatherResponse != null)
                {
                    tempCity.Name = weatherResponse.Name;
                    tempCity.Temperature = weatherResponse.Main.Temp;
                    tempCity.Humidity = weatherResponse.Main.Humidity;
                    tempCity.Pressure = weatherResponse.Main.Pressure;
                    tempCity.Weather = weatherResponse.Weather[0].Main;
                    tempCity.Wind = weatherResponse.Wind.Speed;

                    viewModel.favCities.Add(tempCity);
                }


            }



            return RedirectToAction("SearchByCity", "WeatherForecast", new { cityModel = viewModel });
        }

    }
}
