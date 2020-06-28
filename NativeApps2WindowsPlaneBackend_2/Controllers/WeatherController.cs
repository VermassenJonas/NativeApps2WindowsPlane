using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using NativeApps2WindowsPlaneBackend_2.Models.Dtos;
using Newtonsoft.Json;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet("{location}")]
        public async Task<Weather> GetAsync(string location)
        {
            HttpClient client = new HttpClient();
            try
            {
                String apiKey = "48b09f5981645279d2871db01cf3d3f5"; //TODO: move
                string uri = $"http://api.openweathermap.org/data/2.5/weather?q={location}&appid={apiKey}&units=metric";

                var json = await client.GetStringAsync(@"http://api.openweathermap.org/data/2.5/weather?q=Brussels&appid=48b09f5981645279d2871db01cf3d3f5");
                return  JsonConvert.DeserializeObject<WeatherDto>(json).toWeather();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;

            }
        }
    }
}