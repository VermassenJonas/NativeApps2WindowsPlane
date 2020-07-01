using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Seat
    {
        public string SeatId { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }

        public bool isEmpty()
        {
            return null == Passenger;
        }

        public void placePassenger(Passenger passenger)
        {
            if (isEmpty())
            {
                Passenger = passenger;
                passenger.Seat = this;
            }
        }
        public void Empty()
        {
            if (!isEmpty())
            {
                Passenger.Seat = null;
                Passenger = null;
            }
        }
        public static void swapPassengers(Seat s1, Seat s2)
        {
            Passenger p1 = s1.Passenger;
            Passenger p2 = s2.Passenger;
            s1.Empty();
            s2.Empty();
            s1.placePassenger(p2);
            s2.placePassenger(p1);
        }
    }
}
