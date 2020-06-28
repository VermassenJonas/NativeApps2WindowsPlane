using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NativeApps2WindowsPlane.ViewModels
{
    public class AccessModeVM : INotifyPropertyChanged
    {
        private Visibility _passengerItemVisibility = Visibility.Collapsed;
        public Visibility PassengerItemVisibility
        {
            get
            {
                return _passengerItemVisibility;
            }
            set
            {
                _passengerItemVisibility = value;
                NotifyPropertyChanged("PassengerItemVisibility");
            }
        }
        private Visibility _stewardItemVisibility = Visibility.Collapsed;
        public Visibility StewardItemVisibility
        {
            get
            {
                return _stewardItemVisibility;
            }
            set
            {
                _stewardItemVisibility = value;
                NotifyPropertyChanged("StewardItemVisibility");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
