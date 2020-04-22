using NativeApps2WindowsPlane.Models;
using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Models.Vos;
using NativeApps2WindowsPlane.Models.Vos.Mappers;
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
        public ObservableCollection<MessageVo> MessageList { get; set; }

        private readonly BackendCommService bcs;

        public MessageVM()
        {
            this.MessageList = new ObservableCollection<MessageVo>();
            MessageList.Add(new MessageVo()
            {
                Alignment = "Right",
                Content = "Test",
                Sender = "Jonas",
                Sent = DateTime.Now
            });
            loadDataAsync();

        }
        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();
            do
            {
                try
                {
                    var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/message/"));
                    MessageVoMapper mapper = new MessageVoMapper();
                    IEnumerable<MessageVo> list = JsonConvert.DeserializeObject<List<Message>>(json).Select(m => mapper.MapToVo(m));
                    foreach (MessageVo message in list)
                    {
                        MessageList.Add(message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            } while (false); //TODO: FIX AND MAKE BETTER
            
        }

        public async void AddMessage(string content)
        {
            Message message = new Message()
            {
                Content = content,
                Sent = DateTime.Now,
                Sender = null
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
