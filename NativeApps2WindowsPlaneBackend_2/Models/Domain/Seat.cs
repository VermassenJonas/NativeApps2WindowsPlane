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
    }
}
