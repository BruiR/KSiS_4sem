using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class ClientsListMessage : Message
    {
        public List<ClientInfo> clientInfoList;
        public int YourId;

        public ClientsListMessage(DateTime DateTime, IPAddress senderIp, int senderPort, List<ClientInfo> ClientInfoList, int yourId) : base(DateTime, senderIp, senderPort)
        {
            clientInfoList = ClientInfoList;
            YourId = yourId;
        }
    }
}
