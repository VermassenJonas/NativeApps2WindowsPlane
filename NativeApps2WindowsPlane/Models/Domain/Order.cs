using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Order : INotifyPropertyChanged
    {
        public int OrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Passenger Passenger { get; set; }
        private bool _isProcessed;
        public bool IsProcessed {
            get
            {
                return _isProcessed;
            }
            set
            {
                _isProcessed = value;
                NotifyPropertyChanged("IsProcessed");
                NotifyPropertyChanged("GetProcessed");
                NotifyPropertyChanged("GetNotProcessed");
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return OrderLines.Sum(ol => ol.TotalPrice);
            }
        }
        public Visibility GetProcessed
        {
            get { return IsProcessed == true ? Visibility.Visible : Visibility.Collapsed; }
        }
        public Visibility GetNotProcessed
        {
            get { return IsProcessed == false ? Visibility.Visible : Visibility.Collapsed; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
