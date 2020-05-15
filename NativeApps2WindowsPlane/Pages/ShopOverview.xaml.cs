using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
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
    public sealed partial class ShopOverview : Page
    {
        public ProductVM Products { get; set; }
        public ShopOverview()
        {
            Products = App.container.GetInstance<ProductVM>();
            this.DataContext = Products;
            this.InitializeComponent();
        }


        private void GoToProduct(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                Product selectedProduct = Products.ProductList.SingleOrDefault(p => string.Equals(p.ProductId, b.Tag.ToString()));
                SelectedProductService selectedProductService = App.container.GetInstance<SelectedProductService>();
                selectedProductService.SetCurrentProduct(selectedProduct);
                Frame.Navigate(typeof(Pages.ProductOverview));
            }
        }
    }
}
