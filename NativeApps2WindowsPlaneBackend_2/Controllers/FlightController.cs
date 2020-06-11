﻿using System;
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
    public class FlightController : ControllerBase
    {
        private FlightRepository _flightRepository;

        public FlightController(FlightRepository flightRepository)
        {
            _flightRepository = flightRepository; 
        }

        // GET api/media
        [HttpGet]
        public Flight Get()
        {
            return _flightRepository.GetOne();
        }
    }
}