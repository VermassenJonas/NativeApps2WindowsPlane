using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class FlightRepositoryImpl : FlightRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Flight> _flights;

        public FlightRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
        }
        public Flight GetOne()
        {
            return _flights.FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
