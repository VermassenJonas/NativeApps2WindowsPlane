using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class HttpService
    {
        private static string baseUrl = "http://localhost:51163/api/";


        public static Uri getUri(string uri)
        {
            return new Uri(baseUrl + uri);
        }

    }
}
