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
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController( ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/message
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }
    }
}