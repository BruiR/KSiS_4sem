using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    class ServerObject
    {
        static Socket listenSocket;
        static int port = 8081;
        static string address = "127.0.0.1";
        public List<ClientObject> clients = new List<ClientObject>();

        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }

        public void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null) 
            {
                clients.Remove(client);
            }
                
        }

        protected internal void Listen()
        {
            try
            {
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                Console.WriteLine("Server is working...");
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    ClientObject clientObject = new ClientObject(handler, this);
                    if (clientObject.CheckNewUser())
                    {
                        Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                        clientThread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal void BroadcastMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].client.Send(data);
            }
        }

        public void Disconnect()
        {
            if (listenSocket != null)
                listenSocket.Close();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
            Environment.Exit(0);
        }
    }
}
