using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class OrderVM
    {
        public ObservableCollection<Order> OrderList { get; set; }


        private readonly PassengerIdentificationService passengerIdentificationService = App.container.GetInstance<PassengerIdentificationService>();
        public OrderVM()
        {
            OrderList = new ObservableCollection<Order>();
            loadDataAsync();
        }


        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/order/" + passengerIdentificationService.getCurrentUser().TicketNumber));
                IEnumerable<Order> list = JsonConvert.DeserializeObject<List<Order>>(json);
                foreach (Order order in list)
                {
                    OrderList.Add(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
