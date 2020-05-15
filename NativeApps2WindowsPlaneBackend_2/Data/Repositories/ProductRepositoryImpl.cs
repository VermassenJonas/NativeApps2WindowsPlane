using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class ProductRepositoryImpl : ProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _products;


        public ProductRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _products = dbContext.Products;
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }
    }
}
