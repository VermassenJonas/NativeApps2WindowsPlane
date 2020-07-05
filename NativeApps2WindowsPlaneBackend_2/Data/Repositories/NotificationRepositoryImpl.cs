using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class NotificationRepositoryImpl : NotificationRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Notification> _notifications;
        public NotificationRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _notifications = dbContext.Notifications;
        }
        public void Add(Notification notification)
        {
            foreach (PassengerNotification pn in notification.Recipients)
                _context.Passengers.Attach(pn.Passenger);
            _notifications.Add(notification);
        }

        public List<Notification> GetNotificationsForPassenger(int passengerId)
        {
            return _notifications.Where(n => n.Recipients.Select(pn => pn.PassengerId).Contains(passengerId)).ToList();
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}
