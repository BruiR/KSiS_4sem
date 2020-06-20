using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class HandshakeMessage : Message
    {
        public string ClientName;

        public HandshakeMessage(DateTime DateTime, IPAddress clientIp, int clientPort, string clientName) : base(DateTime, clientIp, clientPort)
        {
            ClientName = clientName;
        }
    }
}

