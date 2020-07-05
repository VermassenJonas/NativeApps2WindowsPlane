using NativeApps2WindowsPlane.Models.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2WindowsPlane.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotificationManagement : Page
    {
        public ObservableCollection<Passenger> PassengerList { get; set; }
        public NotificationManagement()
        {
            PassengerList = new ObservableCollection<Passenger>();
            loadDataAsync();
            this.DataContext = this;
            this.InitializeComponent();
        }

        public async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/passenger/"));
                IEnumerable<Passenger> list = JsonConvert.DeserializeObject<List<Passenger>>(json);
                foreach (Passenger passenger in list)
                {
                    PassengerList.Add(passenger);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PostNotification(object sender, RoutedEventArgs x)
        {
            List<Passenger> selectedPassengers = new List<Passenger>();
            foreach (Object o in PassengerListView.SelectedItems)
            {
                selectedPassengers.Add((Passenger)o);
            }
            Notification notification = new Notification()
            {
                Content = NotificationText.Text,
                Recipients = selectedPassengers
            };

            HttpClient client = new HttpClient();
            try
            {
                client.PostAsync("http://localhost:51163/api/notification/", new StringContent(JsonConvert.SerializeObject(notification), System.Text.Encoding.UTF8, "application/json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
