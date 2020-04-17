using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public String Content { get; set; }
        public List<Passenger> Recipients { get; set; }
    }
}