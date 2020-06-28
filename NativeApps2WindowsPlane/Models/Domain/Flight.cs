using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Origin { get; set; }
        public DateTime Departed { get; set; }
        public DateTime ETA { get; set; }
    }
}
