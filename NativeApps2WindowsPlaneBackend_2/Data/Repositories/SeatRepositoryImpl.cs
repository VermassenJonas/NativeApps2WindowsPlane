using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class SeatRepositoryImpl : SeatRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Seat> _seats;
        public SeatRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _seats = dbContext.Seats;
        }

        public IEnumerable<Seat> getAll()
        {
            return _seats.Include(s => s.Passenger).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Seat seat)
        {
            _context.Passengers.Attach(seat.Passenger);
            _seats.Update(seat);
        }
    }
}
