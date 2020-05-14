using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class ArticleRepositoryImpl : ArticleRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Article> _articles;


        public ArticleRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _articles = dbContext.Articles;
        }

        public IEnumerable<Article> GetAll()
        {
            return _articles.ToList();
        }
    }
}
