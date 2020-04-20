using NativeApps2WindowsPlane.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlane.Models.Vos.Mappers
{
    public class MessageVoMapper : VoMapper<Message, MessageVo>
    {
        public Message MapFromVo(MessageVo vo)
        {
            throw new NotImplementedException(); //TODO: check if needed
        }

        public MessageVo MapToVo(Message o)
        {
            return new MessageVo()
            {
                Sender = "Backend",//o.Sender["FirstName"].ToString(),
                Sent = o.Sent,
                Alignment = "Right",
                Content = o.Content
            };
        }
    }
}
