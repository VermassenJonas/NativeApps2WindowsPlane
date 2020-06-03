
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
    public class MediaVM
    {
        public ObservableCollection<Medium> MediumList { get; set; }

        public MediaVM()
        {
            this.MediumList = new ObservableCollection<Medium>();

            loadDataAsync();
        }
        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/media/"));
                IEnumerable<Medium> list = JsonConvert.DeserializeObject<List<Medium>>(json);
                foreach (Medium message in list)
                {
                    MediumList.Add(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
