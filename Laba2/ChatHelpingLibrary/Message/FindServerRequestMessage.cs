using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class FindServerRequestMessage : Message
    {
        public FindServerRequestMessage(DateTime DateTime, IPAddress senderIp, int senderPort) : base(DateTime, senderIp, senderPort) { }
    }
}
