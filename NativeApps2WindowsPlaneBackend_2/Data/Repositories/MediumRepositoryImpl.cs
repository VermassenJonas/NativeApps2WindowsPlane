using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class MediumRepositoryImpl : MediumRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Medium> _media;

        public MediumRepositoryImpl(AppDbContext context)
        {
            _context = context;
            _media = context.Media;
        }

        public IEnumerable<Medium> getAll()
        {
            return _media.ToList();
        }

        public Medium getById(int id)
        {
            return _media.FirstOrDefault(m => m.MediumId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
