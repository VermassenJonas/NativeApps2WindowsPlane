using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Data.Repositories;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly SeatRepository _seatRepository;

        public SeatController(SeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            return _seatRepository.getAll();
        }

        [HttpPost]
        public void Post([FromBody] List<Seat> seats)
        {
            if(seats.Count == 2)
            {
                Seat.swapPassengers(seats[0], seats[1]);
                _seatRepository.Update(seats[0]);
                _seatRepository.Update(seats[1]);
                _seatRepository.SaveChanges();
            }
        }
    }
}