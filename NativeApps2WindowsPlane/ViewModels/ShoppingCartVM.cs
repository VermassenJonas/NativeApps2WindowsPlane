using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class ShoppingCartVM
    {
        public ObservableCollection<OrderLine> OrderLineList { get; set; }
        public ShoppingCartVM()
        {
            OrderLineList = new ObservableCollection<OrderLine>();
        }
        public void AddProduct(Product product)
        {
            string id = product.ProductId;
            OrderLine orderLine = OrderLineList.FirstOrDefault(ol => string.Equals(ol.LineId, id));
            if (null == orderLine)
            {
                orderLine = new OrderLine()
                {
                    LineId = id,
                    Amount = 1,
                    Product = product
                };
                OrderLineList.Add(orderLine);
            }
            else
            {
                orderLine.Amount += 1;
            }

        }
        public void RemoveProduct(Product product)
        {
            string id = product.ProductId;
            OrderLine orderLine = OrderLineList.FirstOrDefault(ol => string.Equals(ol.LineId, id));
            if (null != orderLine)
            {
                orderLine.Amount -= 1;
                if (orderLine.Amount <= 0)
                {
                    OrderLineList.Remove(orderLine);
                }
            }
        }
    }
}
