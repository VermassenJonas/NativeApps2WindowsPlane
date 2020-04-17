﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public String Destination { get; set; }
        public String Origin { get; set; }
        public DateTime ETA { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Steward> Stewards { get; set; }
        public List<Order> Orders { get; set; }
        public List<TravelGroup> TravelGroups { get; set; }
    }
}