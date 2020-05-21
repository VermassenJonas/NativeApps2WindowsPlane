using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice {
            get
            {
                return Amount * Product.Price;
            }
        }
    }
}
