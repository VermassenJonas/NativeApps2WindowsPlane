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
        private Order order = new Order();
        public void SetCurrentOrder(Order order)
        {
            this.order = order;
        }
        public Order getCurrentOrder()
        {
            return order;
        }
    }
}
