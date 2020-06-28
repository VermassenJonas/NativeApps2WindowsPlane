using NativeApps2WindowsPlane.Pages;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeApps2WindowsPlane
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public AccessModeVM accessModeVM { get; set; }

        public MainPage()
        {
            accessModeVM = App.container.GetInstance<AccessModeVM>();
            this.DataContext = accessModeVM;
            this.InitializeComponent();

        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem x = (NavigationViewItem)args.SelectedItem;
            switch (x.Tag)
            {
                case "login":
                    mainFrame.Navigate(typeof(Pages.Login));
                    break;
                case "flightinfo":
                    mainFrame.Navigate(typeof(Pages.FlightInfo));
                    break;
                case "orderfood":
                    mainFrame.Navigate(typeof(Pages.Shop));
                    break;
                case "myorders":
                    mainFrame.Navigate(typeof(Pages.OrderOverview));
                    break;
                case "chatroom":
                    mainFrame.Navigate(typeof(Pages.ChatRoom));
                    break;
                case "movies":
                    mainFrame.Navigate(typeof(Pages.MediaOverview));
                    break;
            }
        }
    }
}
