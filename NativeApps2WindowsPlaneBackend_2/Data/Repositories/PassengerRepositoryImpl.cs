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

        public void Add(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public void Delete(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Passenger> getAll()
        {
            throw new NotImplementedException();
        }

        public Passenger GetById(int id)
        {
            return _passengers.SingleOrDefault(p => p.TicketNumber == id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
