using NativeApps2WindowsPlane.Models.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class FlightInfoVM : INotifyPropertyChanged
    {
        public Flight flight { get; set; }

        public Weather weather { get; set; }
        public FlightInfoVM()
        {
            
            loadDataAsync();
           
        }
        private async void loadDataAsync()
        {


            HttpClient client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/flight/"));
                flight = JsonConvert.DeserializeObject<Flight>(json);
                NotifyPropertyChanged("flight");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                
                var json = await client.GetStringAsync($"http://localhost:51163/api/weather/{flight.Destination}");
                weather = JsonConvert.DeserializeObject<Weather>(json);
                NotifyPropertyChanged("weather");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
