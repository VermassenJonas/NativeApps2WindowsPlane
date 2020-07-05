using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Data.Repositories;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using NativeApps2WindowsPlaneBackend_2.Models.Dtos;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationRepository _notificationRepository;
        public NotificationController(NotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        [HttpGet("{pid}")]
        public List<Notification> Get(int pid)
        {
            return  _notificationRepository.GetNotificationsForPassenger(pid);
        }

        [HttpPost]
        public void Post([FromBody] NotificationDto notificationDto)
        {
            _notificationRepository.Add(Notification.fromDto(notificationDto));
            _notificationRepository.saveChanges();
        }
    }
}