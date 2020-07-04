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
            _context.Passengers.Attach(order.Passenger);
            foreach (OrderLine ol in order.OrderLines)
                _context.Products.Attach(ol.Product);
            _orders.Add(order);
        }

        public List<Order> getAll()
        {
            return _orders.Include(o => o.Passenger).Include(o => o.OrderLines).ThenInclude(ol => ol.Product).ToList();
        }

        public List<Order> getByPassengerId(int pid)
        {
            return _orders.Include(o => o.OrderLines).ThenInclude(ol => ol.Product).Where(o => o.Passenger.TicketNumber == pid).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Passengers.Attach(order.Passenger);
            foreach (OrderLine ol in order.OrderLines)
                _context.Products.Attach(ol.Product);
            _orders.Update(order);
        }
    }
}
