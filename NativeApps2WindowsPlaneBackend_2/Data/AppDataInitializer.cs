using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data
{
    public class AppDataInitializer
    {
        private readonly AppDbContext _dbContext;

        public AppDataInitializer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Passenger p1 = new Passenger()
                {
                    FirstName = "Jonas",
                    Name = "Vermassen",
                    Seat = "A6",
                    TicketNumber = 1234
                };
                _dbContext.Messages.Add(new Message()
                {
                    Content = "test from backend",
                    MessageId =1,
                    Sender =  p1,
                    Sent = DateTime.Now
                    
                });
                _dbContext.Passengers.Add(p1);
                _dbContext.SaveChanges();

            }
        }
    }
}
