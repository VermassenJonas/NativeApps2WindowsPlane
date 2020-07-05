using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Models.Dtos
{
    public class NotificationDto
    {
        public String Content { get; set; }
        public List<Passenger> Recipients { get; set; }
    }
}
