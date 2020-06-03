using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;

namespace NativeApps2WindowsPlane.Models.Domain
{
    public class Medium
    {
        public int MediumId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string FileLoc { get; set; }
        public List<String> Tags { get; set; }
        public MediaSource MediumSource
        {
            get
            {
                return MediaSource.CreateFromUri(new Uri("http://localhost:51163/api/media/"+ MediumId));
            }
        }
    }
}
