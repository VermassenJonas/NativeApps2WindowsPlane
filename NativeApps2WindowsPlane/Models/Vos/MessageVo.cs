using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Vos
{
    public class MessageVo
    {
        public string Content { get; set; }
        public DateTime Sent { get; set; }
        public string Sender { get; set; }
        public string Alignment { get; set; }
    }
}
