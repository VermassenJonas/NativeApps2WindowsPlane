using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Data.DbConfig;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article>       Articles { get; set; }
        public DbSet<Flight>        Flights { get; set; }
        public DbSet<Medium>        Media { get; set; }
        public DbSet<Message>       Messages { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        public DbSet<Order>         Orders { get; set; }
        public DbSet<OrderLine>     OrderLines { get; set; }
        public DbSet<Passenger>     Passengers { get; set; }
        public DbSet<Steward>       Stewards { get; set; }
        public DbSet<TravelGroup>   TravelGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new MediumConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
            modelBuilder.ApplyConfiguration(new PassengerNotificationConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderLineConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new StewardConfig());
            modelBuilder.ApplyConfiguration(new TravelGroupConfig());

        }
    }
}
