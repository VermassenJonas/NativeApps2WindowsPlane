using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.ViewModels;
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
    public sealed partial class Shop : Page
    {
        public  ProductVM ProductVM { get; set; }
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public Shop()
        {
            ProductVM = App.container.GetInstance<ProductVM>();
            ShoppingCartVM = App.container.GetInstance<ShoppingCartVM>();
            this.DataContext = this;
            this.InitializeComponent();
        }

        public void AddItem(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                string productId = b.Tag.ToString();
                Product product = ProductVM.ProductList.FirstOrDefault(p => string.Equals(p.ProductId, productId));
                ShoppingCartVM.AddProduct(product);
            }
        }
        public void RemoveItem(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                string productId = b.Tag.ToString();
                Product product = ProductVM.ProductList.FirstOrDefault(p => string.Equals(p.ProductId, productId));
                ShoppingCartVM.RemoveProduct(product);
            }
        }
    }
}
