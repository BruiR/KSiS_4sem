using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class Message
    {
        public string DateTime { get; }

        public IPAddress SenderIp { get; }

        public int SenderPort { get; }

        public Message(DateTime dateTime, IPAddress senderIp, int senderPort)
        {
            DateTime = dateTime.ToString(); ;
            SenderIp = senderIp;
            SenderPort = senderPort;
        }
    }
}
