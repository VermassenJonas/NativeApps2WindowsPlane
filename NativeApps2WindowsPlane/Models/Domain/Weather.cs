using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Weather
    {
        public string description { get; set; }
        public string temperature { get; set; }
        public string windSpeed { get; set; }
        public string humidity { get; set; }
    }
}
