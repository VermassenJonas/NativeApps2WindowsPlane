using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article>       Article { get; set; }
        public DbSet<Flight>        Flight { get; set; }
        public DbSet<Medium>        Medium { get; set; }
        public DbSet<Message>       Message { get; set; }
        public DbSet<Notification>  Notification { get; set; }
        public DbSet<Order>         Order { get; set; }
        public DbSet<OrderLine>     OrderLine { get; set; }
        public DbSet<Passenger>     Passenger { get; set; }
        public DbSet<Seat>          Seat { get; set; }
        public DbSet<Steward>       Steward { get; set; }
        public DbSet<TravelGroup>   TravelGroup { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
