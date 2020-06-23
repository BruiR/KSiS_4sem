using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public struct FileInMessage
    {
        public int fileID;
        public string fileName;
    }

    [Serializable]
    public class ChatMessage : Message
    {
        public string Content;
        public bool IsAnyFiles;
        public List<FileInMessage> FilesInMessageList;
        public string SenderName;
        public int SenderId; 
        public int ReceiverId;
        public string dateTime;

        public ChatMessage(DateTime DateTime, IPAddress senderIp, int senderPort, string content, string senderName, int receiverId) : base(DateTime, senderIp, senderPort)
        {
            dateTime = DateTime.ToString();
            Content = content;
            FilesInMessageList = new List<FileInMessage>();
            IsAnyFiles = false;
            ReceiverId = receiverId;
            SenderName = senderName;
        }
    }
}
