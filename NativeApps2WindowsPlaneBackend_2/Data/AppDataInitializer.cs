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
                Passenger p2 = new Passenger()
                {
                    FirstName = "Trifonius",
                    Name = "Valentino",
                    Seat = "A7",
                    TicketNumber = 123
                };
                Message m1 = new Message()
                {
                    Content = "test from backend",
                    MessageId = 1,
                    Sender = p1,
                    Sent = DateTime.Now

                };
                Article a1 = new Article()
                {
                    Name = "Wodka",
                    Price = 15.00m,
                    Stock = 15
                };
                Article a2 = new Article()
                {
                    Name = "Peanuts",
                    Price = 2.50m,
                    Stock = 60
                };
                Article a3 = new Article()
                {
                    Name = "Whiskey",
                    Price = 20.00m,
                    Stock = 12
                };
                Article a4 = new Article()
                {
                    Name = "Chips",
                    Price = 2.50m,
                    Stock = 80
                };
                Article a5 = new Article()
                {
                    Name = "Pizza",
                    Price = 12.00m,
                    Stock = 40
                };
                Article a6 = new Article()
                {
                    Name = "Crystal Meth",
                    Price = 100.00m,
                    Stock = 20
                };
                _dbContext.Articles.Add(a1);
                _dbContext.Articles.Add(a2);
                _dbContext.Articles.Add(a3);
                _dbContext.Articles.Add(a4);
                _dbContext.Articles.Add(a5);
                _dbContext.Articles.Add(a6);
                                       
                _dbContext.Messages.Add(m1);
                _dbContext.Passengers.Add(p1);
                _dbContext.Passengers.Add(p2);
                _dbContext.SaveChanges();

            }
        }
    }
}
