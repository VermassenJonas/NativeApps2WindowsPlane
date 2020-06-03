using System;
using System.Collections.Generic;
using System.IO;
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
    public class MediaController : ControllerBase
    {
        private readonly MediumRepository _mediumRepository;

        public MediaController(MediumRepository mediumRepository)
        {
            _mediumRepository = mediumRepository;
        }
        // GET api/media
        [HttpGet]
        public IEnumerable<Medium> Get()
        {
            return _mediumRepository.getAll();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string pathToMedia = @"D:\WindowsPlaneFiles";
            Medium medium = _mediumRepository.getById(id);
            var path = Path.Combine(pathToMedia, medium.FileLoc);
            string type = "video/mp4";
            if ( string.Equals(medium.Type, "song" ))
            {
                type = "audio/mpeg";
            }

            return File(System.IO.File.OpenRead(path), type);
        }
    }
}