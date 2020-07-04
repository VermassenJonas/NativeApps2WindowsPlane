using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativeApps2WindowsPlaneBackend_2.Data.Repositories;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
        }
        [HttpGet("{pid}")]
        public List<Order> Get(int pid)
        {
            return _orderRepository.getByPassengerId(pid);
        }
        [HttpGet]
        public List<Order> GetAll()
        {
            return _orderRepository.getAll();
        }
        [HttpPut]
        public void UpdateOrder([FromBody] Order order)
        {
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
        }
    }
}