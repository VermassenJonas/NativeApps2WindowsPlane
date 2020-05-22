using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public sealed partial class ShoppingCart : Page
    {
        private Order order = App.container.GetInstance<ShoppingCartService>().getCurrentOrder();
        private readonly PassengerIdentificationService passengerIdentificationService = App.container.GetInstance<PassengerIdentificationService>(); 
        public ShoppingCart()
        {
            this.InitializeComponent();
            this.DataContext = order;
        }
        public void RemoveLine(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                order.OrderLines.RemoveAll(ol => string.Equals(ol.LineId.ToString(), b.Tag.ToString()));
                Frame.Navigate(typeof(Pages.ShoppingCart));
            }
        }
        public async void CommitOrder(object sender, RoutedEventArgs rea)
        {
            try
            {


                HttpClient client = new HttpClient();
                order.Passenger = passengerIdentificationService.getCurrentUser();
                await client.PostAsync("http://localhost:51163/api/order/", new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json"));
                App.container.GetInstance<ShoppingCartService>().ResetCurrentOrder();
                Frame.Navigate(typeof(Pages.ShopOverview));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
