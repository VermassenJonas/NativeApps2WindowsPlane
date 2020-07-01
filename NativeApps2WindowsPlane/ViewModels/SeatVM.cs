using NativeApps2WindowsPlane.Models.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class SeatVM
    {
        public ObservableCollection<Seat> SeatList { get; set; }


        public SeatVM()
        {

            this.SeatList = new ObservableCollection<Seat>();

            loadDataAsync();

        }
        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/seat/"));
                IEnumerable<Seat> list = JsonConvert.DeserializeObject<List<Seat>>(json);
                foreach (Seat seat in list)
                {
                    SeatList.Add(seat);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task swapSeatsAsync(List<Seat> seats)
        {
            HttpClient client = new HttpClient();

            try
            {
                await client.PostAsync("http://localhost:51163/api/seat/", new StringContent(JsonConvert.SerializeObject(seats), System.Text.Encoding.UTF8, "application/json"));
                SeatList.Clear();
                loadDataAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
