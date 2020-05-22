using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}