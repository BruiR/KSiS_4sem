using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    [Serializable]
    public class ClientInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ChatMessage> MessageHistory;
        public ClientInfo() 
        {
            MessageHistory = new List<ChatMessage>();
        }
    }
}
