using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.DbConfig
{
    public class PassengerNotificationConfig : IEntityTypeConfiguration<PassengerNotification>
    {
        public void Configure(EntityTypeBuilder<PassengerNotification> builder)
        {
            builder.ToTable("passenger_notification");
            builder.HasKey(pn => new {pn.PassengerId, pn.NotificationId});

            builder.HasOne(pn => pn.Passenger).WithMany(p => p.Notifications).HasForeignKey(pn => pn.PassengerId);

            builder.HasOne(pn => pn.Notification).WithMany(p => p.Recipients).HasForeignKey(pn => pn.NotificationId);
        }
    }
}
