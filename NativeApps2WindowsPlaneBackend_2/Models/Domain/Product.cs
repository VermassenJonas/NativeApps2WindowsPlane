using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}