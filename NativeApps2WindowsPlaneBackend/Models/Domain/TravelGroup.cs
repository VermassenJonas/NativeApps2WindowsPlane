using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend.Models.Domain
{
    public class TravelGroup
    {
        [Key]
        public int TravelGroupId { get; set; }
        public List<Message> Messages { get; set; }
    }
}