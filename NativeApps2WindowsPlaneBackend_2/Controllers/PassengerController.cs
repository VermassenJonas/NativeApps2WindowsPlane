using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerRepository _passengerRepository;

        // GET: api/Passenger
        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Passenger/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Passenger
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Passenger/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
