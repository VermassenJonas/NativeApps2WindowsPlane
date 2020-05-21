using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Order> _orders;

        public OrderRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _orders = dbContext.Orders;
        }
        public void Add(Order order)
        {
            foreach (OrderLine ol in order.OrderLines)
                _context.Products.Attach(ol.Product);
            _orders.Add(order);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
