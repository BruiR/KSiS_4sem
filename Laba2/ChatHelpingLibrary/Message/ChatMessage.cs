using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class ChatMessage : Message
    {
        public string Content;
        public string senderName;
        public int SenderId; 
        public int ReceiverId;
        public string dateTime;

        public ChatMessage(DateTime DateTime, IPAddress senderIp, int senderPort, string content, string SenderName, int receiverId) : base(DateTime, senderIp, senderPort)
        {
            dateTime = DateTime.ToString();
            Content = content;
            //SenderId = senderId;
            ReceiverId = receiverId;
            senderName = SenderName;
        }
    }
}
