﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public DateTime Departed { get; set; }
        public DateTime ETA { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Steward> Stewards { get; set; }
        public List<Order> Orders { get; set; }
        public List<TravelGroup> TravelGroups { get; set; }
        public List<Seat> Seats { get; set; }

        public Flight()
        {
            Passengers = new List<Passenger>();
            Stewards = new List<Steward>();
            Orders = new List<Order>();
            TravelGroups = new List<TravelGroup>();
            Seats = new List<Seat>();
        }
    }
}