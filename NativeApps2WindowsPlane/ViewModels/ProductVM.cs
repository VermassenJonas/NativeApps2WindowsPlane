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
    public class ProductVM
    {

        public ObservableCollection<Product> ProductList { get; set; }

        public ProductVM()
        {
            this.ProductList = new ObservableCollection<Product>();

            loadDataAsync();
        }

        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();
            
                try
                {
                    var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/product/"));
                    IEnumerable<Product> list = JsonConvert.DeserializeObject<List<Product>>(json);
                    foreach (Product product in list)
                    {
                        ProductList.Add(product);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

        }
    }
}
