using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public interface TravelGroupRepository
    {
        TravelGroup GetById(int tgid);
        TravelGroup GetByPassengerId(int pid);
        void SaveChanges();
    }
}
