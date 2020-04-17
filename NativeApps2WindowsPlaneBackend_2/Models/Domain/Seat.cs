using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        public String SeatNumber { get; set; }
    }
}