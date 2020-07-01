using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public interface SeatRepository
    {
        IEnumerable<Seat> getAll();
        void Update(Seat seat);
        void SaveChanges();
    }
}
