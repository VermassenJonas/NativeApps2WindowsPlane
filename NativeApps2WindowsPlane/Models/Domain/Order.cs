using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Passenger Passenger { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return OrderLines.Sum(ol => ol.TotalPrice);
            }

        }
    }
}
