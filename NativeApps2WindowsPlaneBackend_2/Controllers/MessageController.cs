using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Data.Repositories;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly MessageRepository _messageRepository;
        private readonly PassengerRepository _passengerRepository;
        public MessageController(MessageRepository messageRepository, PassengerRepository passengerRepository)
        {
            _messageRepository = messageRepository;
            _passengerRepository = passengerRepository;
        }



        // GET api/message
        [HttpGet]
        public IEnumerable<Message> Get()
        {
           return _messageRepository.getAll();
        }
        // POST api/message
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            message.Sender = _passengerRepository.GetById(message.Sender.TicketNumber);
            _messageRepository.Add(message);
            _messageRepository.SaveChanges();
        }
    }
}
