using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Models.Dtos
{
    public class WeatherDto
    {

        public List<Dictionary<string, string>> weather { get; set; }
        public Dictionary<string, string> main { get; set; }
        public Dictionary<string, string> wind { get; set; }
        public Dictionary<string, string> clouds { get; set; }

        public Weather toWeather()
        {
            return new Weather()
            {
                description = weather.Single()["description"],
                temperature = main["temp"],
                humidity = main["humidity"],
                windSpeed = wind["speed"]
            };
        }
    }
}
