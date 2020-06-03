using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Passenger
    {
        public int TicketNumber { get; set; }
        public String FirstName { get; set; }
        public String Name { get; set; }
        public String Seat { get; set; }
        public string FullName { get
            {
                return $"{FirstName} {Name}";
            }
        }

    }
}
