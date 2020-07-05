using NativeApps2WindowsPlaneBackend_2.Models.Dtos;
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
        public List<PassengerNotification> Recipients { get; set; }


        public static Notification fromDto(NotificationDto notificationDto)
        {
            
            Notification result = new Notification();
            result.Content = notificationDto.Content;
            result.Recipients = notificationDto.Recipients.Select(p => new PassengerNotification() { Passenger = p, PassengerId = p.TicketNumber, Notification = result }).ToList();
            return result;
        }
    }
}