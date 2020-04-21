using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Passenger
    {
        public int TicketNumber { get; set; }
        public String FirstName { get; set; }
        public String Name { get; set; }
        public String Seat { get; set; }
        public List<Order> Orders { get; set; }
        public List<PassengerNotification> Notifications { get; set; }
        public TravelGroup TravelGroup { get; set; }
    }
}