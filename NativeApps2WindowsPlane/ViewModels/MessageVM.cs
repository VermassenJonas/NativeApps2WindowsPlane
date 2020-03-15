using NativeApps2WindowsPlane.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class MessageVM
    {
        public ObservableCollection<Message> MessageList { get; set; }

        public MessageVM()
        {
            this.MessageList = new ObservableCollection<Message>();
            MessageList.Add(new Message()
            {
                Alignment = "Right",
                Content = "Test",
                Sender = "Jonas",
                Sent = DateTime.Now
            });
        }
    }
}
