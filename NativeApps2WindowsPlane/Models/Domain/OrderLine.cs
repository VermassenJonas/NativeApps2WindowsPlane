using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class OrderLine : INotifyPropertyChanged
    {
        public string LineId { get; set; }
        public Product Product { get; set; }



        

        private int _amount;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("Amount");
                NotifyPropertyChanged("TotalPrice");
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return Amount * Product.Price;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
