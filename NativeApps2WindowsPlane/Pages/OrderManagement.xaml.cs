﻿using NativeApps2WindowsPlane.ViewModels;
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
    public sealed partial class OrderManagement : Page
    {
        public OrderManagementVM Orders{ get; set; }
        public OrderManagement()
        {
            Orders = App.container.GetInstance<OrderManagementVM>();
            this.DataContext = Orders;
            this.InitializeComponent();
        }
        public void ToggleOrderProcessed(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                int orderId = Int32.Parse( b.Tag.ToString());
                Orders.ToggleOrderProcessed(orderId);
            }
        }
    }
}
