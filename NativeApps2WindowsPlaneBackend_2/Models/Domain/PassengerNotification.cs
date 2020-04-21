using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class PassengerNotification
    {

        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }


    }
}
