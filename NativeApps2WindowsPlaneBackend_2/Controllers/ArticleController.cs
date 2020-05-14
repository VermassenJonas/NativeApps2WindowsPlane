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
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRepository _articleRepository;

        public ArticleController( ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // GET api/message
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _articleRepository.GetAll();
        }
    }
}