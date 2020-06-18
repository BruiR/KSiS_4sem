using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatHelpingLibrary;

namespace Chat
{
    public class ClientDataset
    {
        public ClientObject clientObject;
        public ClientInfo clientInfo;
        public ClientDataset() 
        {
            clientInfo = new ClientInfo();
        }

    }
}
