using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Data.Repositories;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using NativeApps2WindowsPlaneBackend_2.Models.Dtos;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StewardController : ControllerBase
    {

        private readonly StewardRepository _stewardRepository;
        public StewardController(StewardRepository stewardRepository)
        {
            _stewardRepository = stewardRepository;
        }
        [HttpPost]
        public Steward Login([FromBody] LoginDto loginDto)
        {
            return _stewardRepository.getById(loginDto.PersonnelId);
        }
    }
}