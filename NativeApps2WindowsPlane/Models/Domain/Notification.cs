using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Notification
    {
        public String Content { get; set; }
        public List<Passenger> Recipients { get; set; }
    }
}
