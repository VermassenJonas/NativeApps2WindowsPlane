using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Models.dtos;
using NativeApps2WindowsPlane.Services;
using NativeApps2WindowsPlane.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class Login : Page, INotifyPropertyChanged
    {

        private Visibility _passengerVisibility = Visibility.Visible;
        public Visibility PassengerVisibility
        {
            get
            {
                return _passengerVisibility;
            }
            set
            {
                _passengerVisibility = value;
                NotifyPropertyChanged("PassengerVisibility");
            }
        }
        private Visibility _stewardVisibility = Visibility.Collapsed;
        public Visibility StewardVisibility
        {
            get
            {
                return _stewardVisibility;
            }
            set
            {
                _stewardVisibility = value;
                NotifyPropertyChanged("StewardVisibility");
            }
        }
        public Login()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }
        public void SwitchToCrew(object sender, RoutedEventArgs e)
        {
            PassengerVisibility = Visibility.Collapsed;
            StewardVisibility = Visibility.Visible;
        }
        public void SwitchToPassenger(object sender, RoutedEventArgs e)
        {
            PassengerVisibility = Visibility.Visible;
            StewardVisibility = Visibility.Collapsed;
        }
        private async void SignInAsPassenger(object sender, RoutedEventArgs ea)
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/passenger/" + PassengerLoginInput.Text));

                Passenger user = JsonConvert.DeserializeObject<Passenger>(json);
                App.container.GetInstance<PassengerIdentificationService>().SetCurrentUser(user);
                AccessModeVM avm = App.container.GetInstance<AccessModeVM>();
                avm.StewardItemVisibility = Visibility.Collapsed;
                avm.PassengerItemVisibility = Visibility.Visible;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private async void SignInAsSteward(object sender, RoutedEventArgs ea)
        {
            try
            {
                HttpClient client = new HttpClient();
                LoginDto loginDto = new LoginDto()
                {
                    PersonnelId = CrewLoginInput.Text,
                    Password = CrewPasswordInput.Text
                };
                HttpResponseMessage hrm = await client.PostAsync(new Uri("http://localhost:51163/api/steward/"), new StringContent(JsonConvert.SerializeObject(loginDto), System.Text.Encoding.UTF8, "application/json"));
                var json = await hrm.Content.ReadAsStringAsync();
                App.container.GetInstance<StewardIdentificationService>().SetCurrentUser(JsonConvert.DeserializeObject<Steward>(json));
                AccessModeVM avm = App.container.GetInstance<AccessModeVM>();
                avm.PassengerItemVisibility = Visibility.Collapsed;
                avm.StewardItemVisibility = Visibility.Visible;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
