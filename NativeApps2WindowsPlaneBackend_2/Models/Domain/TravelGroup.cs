using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class TravelGroup
    {
        public int TravelGroupId { get; set; }
        public List<Passenger> Passengers { get; set; }
        public TravelGroup()
        {
            Passengers = new List<Passenger>();
        }


        public void AddPassenger(Passenger passenger)
        {
            passenger.TravelGroup = this;
            Passengers.Add(passenger);
        }
    }
}