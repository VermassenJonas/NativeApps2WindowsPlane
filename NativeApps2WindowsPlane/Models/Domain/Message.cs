using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public String Content { get; set; }
        public DateTime Sent { get; set; }
        public Passenger Sender { get; set; } //TODO: fix to Passenger
    }
}
