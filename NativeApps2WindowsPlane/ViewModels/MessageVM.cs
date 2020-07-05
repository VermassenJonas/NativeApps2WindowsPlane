using NativeApps2WindowsPlane.Models;
using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
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
    public class MessageVM
    {
        public ObservableCollection<Message> MessageList { get; set; }

        private readonly PassengerIdentificationService passengerIdentificationService;



        public MessageVM(PassengerIdentificationService passengerIdentificationService)
        {

            this.passengerIdentificationService = passengerIdentificationService;
            this.MessageList = new ObservableCollection<Message>();

            loadDataAsync();

        }
        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();
            do
            {

                try //TODO: fetch auto
                {
                    var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/message/" + passengerIdentificationService.getCurrentUser().TicketNumber));
                    IEnumerable<Message> list = JsonConvert.DeserializeObject<List<Message>>(json);
                    MessageList.Clear();
                    foreach (Message message in list)
                    {
                        MessageList.Add(message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                await Task.Delay(TimeSpan.FromSeconds(5));//Quick & Dirty maar we krijgen push notes niet in gang
            } while (true);
        }

        public async void AddMessage(string content)
        {
            Message message = new Message()
            {
                Content = content,
                Sent = DateTime.Now,
                Sender = passengerIdentificationService.getCurrentUser()
            };

            try
            {


                HttpClient client = new HttpClient();
                await client.PostAsync("http://localhost:51163/api/message/", new StringContent(JsonConvert.SerializeObject(message), System.Text.Encoding.UTF8, "application/json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
