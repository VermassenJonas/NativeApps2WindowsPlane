using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class ShoppingCartService
    {
        private int orderLineIdCounter = 0;
        private Order order = new Order()
        {
            OrderLines = new List<OrderLine>()
        };
        public void SetCurrentOrder(Order order)
        {
            this.order = order;
        }
        public void ResetCurrentOrder()
        {
            order = new Order()
            {
                OrderLines = new List<OrderLine>()
            };
        }
        public Order getCurrentOrder()
        {
            return order;
        }
        public int getNewOrderLineId()
        {
            return ++orderLineIdCounter;
        }
    }
}
