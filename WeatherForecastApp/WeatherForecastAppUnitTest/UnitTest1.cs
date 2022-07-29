using NUnit.Framework;
using System;
using WeatherForecastApp.OpenWeatherMap_Model;
using WeatherForecastApp.Repositories;

namespace WeatherForecastAppUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchCityTest()
        {

            string cityName = "london";

            WForecastRepository _WForecastRepository = new WForecastRepository(); 
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(cityName);

            if (weatherResponse.Name.ToLower().Contains("province"))
            {
                Assert.IsTrue((cityName.ToLower()+" province").Equals(weatherResponse.Name.ToLower()));
            }
            else
            {
                Assert.IsTrue((cityName.ToLower()).Equals(weatherResponse.Name.ToLower()));
            }
            
            

        }
        [Test]
        public void AddFavCityTest()
        {
            string cityName = "adana";
            CityNameRepository.AddCity(cityName);
            
            Assert.IsTrue(CityNameRepository._favCities.Contains(cityName));
        }
    }
}