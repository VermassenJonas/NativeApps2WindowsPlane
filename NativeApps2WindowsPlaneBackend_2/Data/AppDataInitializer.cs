﻿using NativeApps2WindowsPlaneBackend_2.Models.Domain;
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
                Product a1 = new Product()
                {
                    Name = "Wodka",
                    Price = 15.00m,
                    Stock = 15
                };
                Product a2 = new Product()
                {
                    Name = "Peanuts",
                    Price = 2.50m,
                    Stock = 60
                };
                Product a3 = new Product()
                {
                    Name = "Whiskey",
                    Price = 20.00m,
                    Stock = 12
                };
                Product a4 = new Product()
                {
                    Name = "Chips",
                    Price = 2.50m,
                    Stock = 80
                };
                Product a5 = new Product()
                {
                    Name = "Pizza",
                    Price = 12.00m,
                    Stock = 40
                };
                Product a6 = new Product()
                {
                    Name = "Crystal Meth",
                    Price = 100.00m,
                    Stock = 20
                };
                Medium med1 = new Medium()
                {
                    Title = "The Fellowship of the Ring",
                    FileLoc = "Hobbits.mp4",
                    Tags = new List<string>(){"Fantasy", "Tolkien", "Adventure"},
                    Type = "movie"
                };
                Medium med2 = new Medium()
                {
                    Title = "Star Wars",
                    FileLoc = "Hobbits_2.mp4",
                    Tags = new List<string>() { "Sci Fi", "Adventure" },
                    Type = "movie"
                };
                Medium med3 = new Medium()
                {
                    Title = "Twilight Techno",
                    FileLoc = "Twilight_Techno.mp3",
                    Tags = new List<string>() { "Techno" },
                    Type = "song"
                };
                _dbContext.Products.Add(a1);
                _dbContext.Products.Add(a2);
                _dbContext.Products.Add(a3);
                _dbContext.Products.Add(a4);
                _dbContext.Products.Add(a5);
                _dbContext.Products.Add(a6);
                                       
                _dbContext.Messages.Add(m1);

                _dbContext.Passengers.Add(p1);
                _dbContext.Passengers.Add(p2);

                _dbContext.Media.AddRange(med1, med2, med3);

                _dbContext.SaveChanges();

            }
        }
    }
}
