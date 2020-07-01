using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Passenger Passenger { get; set; }
        public bool IsProcessed { get; set; }
    }
}