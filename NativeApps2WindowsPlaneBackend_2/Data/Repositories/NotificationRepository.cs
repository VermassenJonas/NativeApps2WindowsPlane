using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public interface NotificationRepository
    {
        List<Notification> GetNotificationsForPassenger(int passengerId);
        void Add(Notification notification);
        void saveChanges();

    }
}   
