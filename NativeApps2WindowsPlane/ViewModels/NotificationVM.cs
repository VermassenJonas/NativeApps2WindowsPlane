using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class NotificationVM
    {
        public ObservableCollection<Notification> NotificationList { get; set; }

        private readonly PassengerIdentificationService passengerIdentificationService;
        public NotificationVM()
        {
            this.passengerIdentificationService = App.container.GetInstance<PassengerIdentificationService>();
            this.NotificationList = new ObservableCollection<Notification>();
            //var t = new Timer(o => loadDataAsync(), null, 0, 30000);//Quick & Dirty maar we krijgen push notes niet in gang
            loadDataAsync();
        }
        private void fillObservableList(IEnumerable<Notification> notifications)
        {
            NotificationList.Clear();
            foreach(Notification notification in notifications)
            {
                NotificationList.Add(notification);
            }
        }
        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            
                try
                {
                    var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/notification/" + passengerIdentificationService.getCurrentUser().TicketNumber));
                    IEnumerable<Notification> list = JsonConvert.DeserializeObject<IEnumerable<Notification>>(json);
                    fillObservableList(list);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


        }
    }
}
