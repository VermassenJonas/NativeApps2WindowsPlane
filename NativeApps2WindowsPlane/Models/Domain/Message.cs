using NativeApps2WindowsPlane.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public String Content { get; set; }
        public DateTime Sent { get; set; }
        public Passenger Sender { get; set; }

        public HorizontalAlignment Alignment
        {
            get
            {
                return (Sender.TicketNumber == App.container.GetInstance<PassengerIdentificationService>().getCurrentUser().TicketNumber) ? HorizontalAlignment.Left : HorizontalAlignment.Right;
            }
        }
    }
}
