using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class StewardRepositoryimpl : StewardRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Steward> _stewards;

        public StewardRepositoryimpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _stewards = dbContext.Stewards;
        }
        public Steward getById(string personnelNumber)
        {
            return _stewards.Where(s => String.Equals(s.PersonnelNumber, personnelNumber)).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
