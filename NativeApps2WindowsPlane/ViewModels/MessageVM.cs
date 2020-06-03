﻿using NativeApps2WindowsPlane.Models;
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

        private readonly PassengerIdentificationService passengerIdentificationService;

        public MessageVM(PassengerIdentificationService passengerIdentificationService)
        {

            this.passengerIdentificationService = passengerIdentificationService;
            this.MessageList = new ObservableCollection<MessageVo>();

            loadDataAsync();

        }
        private async void loadDataAsync()
        {

            HttpClient client = new HttpClient();

            try //TODO: fetch auto
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
