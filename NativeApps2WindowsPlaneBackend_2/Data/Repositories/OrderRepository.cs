using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public interface OrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void SaveChanges();
        List<Order> getByPassengerId(int pid);
        List<Order> getAll();
    }
}

