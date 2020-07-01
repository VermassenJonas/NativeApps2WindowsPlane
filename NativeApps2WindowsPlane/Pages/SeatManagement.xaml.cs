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
    public sealed partial class SeatManagement : Page
    {
        public SeatVM Seats { get; set; }
        public SeatManagement()
        {
            Seats = App.container.GetInstance<SeatVM>();
            this.DataContext = Seats;
            this.InitializeComponent();
        }

        public void swapTwoSeats()
        {
            List<Seat> selectedSeats = SeatListView.SelectedItems as List<Seat>;
            if(selectedSeats.Count() == 2)
            {
                Seats.swapSeatsAsync(selectedSeats);
            }
        }
        
    }
}
