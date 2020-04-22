using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Services
{
    public class BackendCommService
    {

        private readonly HttpClient client = new HttpClient();

        private readonly string baseUrl = "http://localhost:51163/api";
       
    }
}
