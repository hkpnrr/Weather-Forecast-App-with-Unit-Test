using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class City
    {
        [Required(ErrorMessage = "City name is empty!")]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid input")]
        public string Name { get; set; }
        public float Temperature { get; set; }
        [Display(Name = "City Humidity:")]
        public int Humidity { get; set; }
        [Display(Name = "Pressure:")]
        public int Pressure { get; set; }
        [Display(Name = "Wind Speed:")]
        public float Wind { get; set; }
        [Display(Name = "Weather Condition:")]
        public string Weather { get; set; }
        }
}
