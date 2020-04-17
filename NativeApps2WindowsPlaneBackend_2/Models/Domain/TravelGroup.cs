using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class TravelGroup
    {
        public int TravelGroupId { get; set; }
        public List<Message> Messages { get; set; }
    }
}