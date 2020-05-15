using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class ProductOverview : Page
    {
        public OrderLine orderLine { get; set; }

        public ProductOverview()
        {
            Product selectedProduct = App.container.GetInstance<SelectedProductService>().getCurrentProduct();
            orderLine = new OrderLine()
            {
                Product = selectedProduct,
                Amount = 1
            };
            this.DataContext = this;
            this.InitializeComponent();
        }
        public void AddOrderLineToCart()
        {
            App.container.GetInstance<ShoppingCartService>().getCurrentOrder().OrderLines.Add(orderLine);
            Frame.Navigate(typeof(Pages.ShopOverview));
        }
        public void AddItem()
        {
            orderLine.Amount = orderLine.Amount + 1;
        }
        public void RemoveItem()
        {
            orderLine.Amount = orderLine.Amount - 1;
        }
    }
}
