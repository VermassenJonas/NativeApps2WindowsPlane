using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class PassengerRepositoryImpl : PassengerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Passenger> _passengers;


        public PassengerRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _passengers = dbContext.Passengers;
        }

        public List<Passenger> GetAll()
        {
            return _passengers.ToList();
        }

        public Passenger GetById(int id)
        {
            return _passengers.SingleOrDefault(p => p.TicketNumber == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
