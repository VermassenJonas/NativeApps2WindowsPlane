using NativeApps2WindowsPlane.Models.Domain;
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
    public class OrderManagementVM
    {
        public ObservableCollection<Order> OrderList { get; set; }

        public OrderManagementVM()
        {
            OrderList = new ObservableCollection<Order>();
            loadDataAsync();
        }

        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/order/"));
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

        public async void updateOrder(Order order)
        {
            HttpClient client = new HttpClient();

            try
            {
                await client.PutAsync("http://localhost:51163/api/order/", new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ToggleOrderProcessed(int orderId)
        {
            Order order = OrderList.Where(o => o.OrderId == orderId).SingleOrDefault();
            order.IsProcessed = !order.IsProcessed;
            updateOrder(order);
        }

    }
}
