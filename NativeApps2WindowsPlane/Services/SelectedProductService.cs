
using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class SelectedProductService
    {
        private Product product;
        public void SetCurrentProduct(Product product)
        {
            this.product = product;
        }

        public Product getCurrentProduct()
        {
            return product;
        }
    }
}
