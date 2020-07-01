using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Seat
    {
        public string SeatId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
