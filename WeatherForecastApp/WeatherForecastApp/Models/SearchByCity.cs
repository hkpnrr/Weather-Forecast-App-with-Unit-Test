using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class SearchByCity
    {
        [Required(ErrorMessage ="City name is empty!")]
        [Display(Name ="City Name")]
        [StringLength(30,MinimumLength =2,ErrorMessage ="Invalid input")]
        public string CityName { get; set; }

        public List<City> favCities { get; set; }



    }
}
