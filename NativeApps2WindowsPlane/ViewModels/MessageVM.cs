using NativeApps2WindowsPlane.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
            loadDataAsync();
        }
        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/message/"));
        }
    }
}
