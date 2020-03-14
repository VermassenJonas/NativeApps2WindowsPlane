using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend.Models
{
    public class NativeApps2WindowsPlaneBackendContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NativeApps2WindowsPlaneBackendContext() : base("name=NativeApps2WindowsPlaneBackendContext")
        {
        }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Article> Articles { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Flight> Flights { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Medium> Media { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.OrderLine> OrderLines { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Passenger> Passengers { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Seat> Seats { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.Steward> Stewards { get; set; }

        public System.Data.Entity.DbSet<NativeApps2WindowsPlaneBackend.Models.Domain.TravelGroup> TravelGroups { get; set; }
    }
}
