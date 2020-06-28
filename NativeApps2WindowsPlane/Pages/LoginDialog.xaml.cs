using NativeApps2WindowsPlane.Models.Domain;
using NativeApps2WindowsPlane.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2WindowsPlane.Pages
{
    public sealed partial class LoginDialog : ContentDialog
    {
        public LoginDialog()
        {
            this.InitializeComponent();
        }

        private async  void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                HttpClient client = new HttpClient();      
                var json = await client.GetStringAsync(new Uri("http://localhost:51163/api/passenger/" + LoginInput.Text));

                Passenger user = JsonConvert.DeserializeObject<Passenger>(json);
                App.container.GetInstance<PassengerIdentificationService>().SetCurrentUser(user);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
           
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            new StewardLoginDialog().ShowAsync();
        }


    }
}
