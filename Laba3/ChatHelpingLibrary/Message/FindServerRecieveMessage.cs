using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class FindServerRecieveMessage : Message
    {
        public FindServerRecieveMessage(DateTime DateTime, IPAddress serverIp, int serverPort) : base(DateTime, serverIp, serverPort)
        {
        }
    }
}
