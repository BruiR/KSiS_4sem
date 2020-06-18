using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {       
            ServerObject server = new ServerObject();
            if (server.Start())
            {
                Thread listenUdpThread = new Thread(new ThreadStart(server.ListenUdp));
                Thread listenTcpThread = new Thread(new ThreadStart(server.ListenTcpAccept));
                listenUdpThread.Start();
                listenTcpThread.Start();
            }
                      
        }
    }
}
