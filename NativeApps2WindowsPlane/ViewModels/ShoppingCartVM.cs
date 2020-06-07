using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class ShoppingCartVM : INotifyPropertyChanged
    {
        public ObservableCollection<OrderLine> OrderLineList { get; set; }
        public decimal TotalPrice { get {
                return OrderLineList.Select(ol => ol.TotalPrice).Sum();
            }
        }
        public ShoppingCartVM()
        {
            OrderLineList = new ObservableCollection<OrderLine>();
        }
        public void AddProduct(Product product)
        {
            string id = product.ProductId;
            OrderLine orderLine = OrderLineList.FirstOrDefault(ol => string.Equals(ol.LineId, id));
            if (null == orderLine)
            {
                orderLine = new OrderLine()
                {
                    LineId = id,
                    Amount = 1,
                    Product = product
                };
                OrderLineList.Add(orderLine);
            }
            else
            {
                orderLine.Amount += 1;
                
            }
            NotifyPropertyChanged("TotalPrice");
        }
        public void RemoveProduct(Product product)
        {
            string id = product.ProductId;
            OrderLine orderLine = OrderLineList.FirstOrDefault(ol => string.Equals(ol.LineId, id));
            if (null != orderLine)
            {
                orderLine.Amount -= 1;
                if (orderLine.Amount <= 0)
                {
                    OrderLineList.Remove(orderLine);
                }
            }
            NotifyPropertyChanged("TotalPrice");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void CommitOrder()
        {
            try
            {


                HttpClient client = new HttpClient();
                Order order = new Order()
                {
                    Passenger = App.container.GetInstance<PassengerIdentificationService>().getCurrentUser(),
                    OrderLines = OrderLineList.ToList()
                };
                await client.PostAsync("http://localhost:51163/api/order/", new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json"));
                OrderLineList.Clear();
                NotifyPropertyChanged("TotalPrice");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
