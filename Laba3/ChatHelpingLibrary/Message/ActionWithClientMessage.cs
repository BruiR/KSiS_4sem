using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class ActionWithClientMessage : Message
    {
        public int ActionType { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public ActionWithClientMessage(DateTime DateTime, IPAddress senderIp, int senderPort, string clientName, int clientId, int actionType) : base(DateTime, senderIp, senderPort)
        {
            ClientName = clientName;
            ClientId = clientId;
            ActionType = actionType;
        }
    }
}
