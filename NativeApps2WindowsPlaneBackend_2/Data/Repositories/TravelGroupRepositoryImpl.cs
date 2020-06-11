using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class TravelGroupRepositoryImpl : TravelGroupRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TravelGroup> _travelgroups;

        public TravelGroupRepositoryImpl(AppDbContext context)
        {
            _context = context;
            _travelgroups = context.TravelGroups;
        }

        public TravelGroup GetById(int tgid)
        {
            return _travelgroups.Include(tg => tg.Passengers).SingleOrDefault(tg => tg.TravelGroupId == tgid);
        }

        public TravelGroup GetByPassengerId(int pid)
        {
            return _travelgroups.Include(tg => tg.Passengers).SingleOrDefault(tg => tg.Passengers.Exists(p => p.TicketNumber == pid));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
