using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using ChatHelpingLibrary;
using System.IO;

namespace Chat
{
    public class ServerObject
    {
        private Socket listenTcpSocket;
        private Socket listenUdpSocket;
        private int port = 50000;
        public List<ClientDataset> clientDatasets;
        private Serializer serializer;
        public int id;
        public IPAddress servIp;
        public Thread threadClient;

        public ServerObject()
        {
            id = 1;
            serializer = new Serializer();
            clientDatasets = new List<ClientDataset>();
            ClientDataset chatDataset = new ClientDataset();
            chatDataset.clientInfo.Name = "General chat";
            chatDataset.clientInfo.Id = 0;
            clientDatasets.Add(chatDataset);
        }

        public bool Start()
        {
            listenTcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenUdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listenUdpSocket.EnableBroadcast = true;            
            IPEndPoint UdpIpEndPoint = new IPEndPoint(IPAddress.Any, port);
            servIp = GetIp();
            Console.WriteLine("server Ip =  " + servIp);
            Console.WriteLine("server port =  " + port);
            IPEndPoint TcpIpEndPoint = new IPEndPoint(servIp, port);
            try
            {
                listenUdpSocket.Bind(UdpIpEndPoint);
                listenTcpSocket.Bind(TcpIpEndPoint);
                Console.WriteLine("Server is working... ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void ListenTcpAccept()
        {
            listenTcpSocket.Listen(20);
            while (true)
            {
                try 
                {
                    Socket handler = listenTcpSocket.Accept();
                    ClientObject clientObject = new ClientObject(handler, this);
                    threadClient = new Thread(clientObject.WaitHandshakeMessage);
                    threadClient.Start();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ListenUdp()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint endPoint = ipEndPoint;
            int bytesCount;
            byte[] data;
            while (true)
            {
                try
                {
                    data = new byte[1024];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        do
                        {
                            bytesCount = listenUdpSocket.ReceiveFrom(data, data.Length, SocketFlags.None, ref endPoint);
                            memoryStream.Write(data, 0, bytesCount);
                        }
                        while (listenUdpSocket.Available > 0);
                        if (bytesCount > 0) 
                        {
                            ReceiveUdpMessage(serializer.MakeDeserialize(memoryStream.ToArray()));
                            Console.WriteLine(" кто-то послал запрос  на поиск сервера.");
                        }                            
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        protected internal void AddConnection(ClientDataset clientDataset)
        {
            СlientSignInOutMessage(clientDataset.clientInfo.Name, clientDataset.clientInfo.Id, 1);
            clientDatasets.Add(clientDataset);
            Console.WriteLine("AddConnection");
            ClientsListMessage clientsListMessage =CreateClientListMessage(clientDataset.clientInfo.Id);
            clientDataset.clientObject.client.Send(serializer.MakeSerialize(clientsListMessage));
        }

        public ClientsListMessage CreateClientListMessage(int Id)
        {
            List<ClientInfo> clientInfoList = new List<ClientInfo>();
            foreach (ClientDataset clientDataset in clientDatasets) 
            {
                clientInfoList.Add(clientDataset.clientInfo);
            }
            ClientsListMessage clientsListMessage = new ClientsListMessage(DateTime.Now, servIp, port, clientInfoList, Id);
            return clientsListMessage;
        }


        public void RemoveConnection(int id)
        {
            ClientDataset client = clientDatasets.FirstOrDefault(c => c.clientInfo.Id == id);
            if (client.clientObject != null) 
            {
                clientDatasets.Remove(client);
            }
                
        }

        protected internal void BroadcastMessage(Message message)
        {
            byte[] mes = serializer.MakeSerialize(message);
            for (int i = 1; i < clientDatasets.Count; i++)
            {
                clientDatasets[i].clientObject.client.Send(mes);                
            }
        }
        
        public void SendMessageToChatRoom(ChatMessage chatMessage, Socket SenderclientSocket)
        {
            byte[] newMessage = serializer.MakeSerialize(chatMessage);
            for (int i = 1; i < clientDatasets.Count; i++)
            {
                if (clientDatasets[i].clientObject.client != SenderclientSocket)
                {
                    clientDatasets[i].clientObject.client.Send(newMessage);
                }
            }
        }
        public void SendMessageToPrivateRoom(ChatMessage chatMessage, Socket SenderclientSocket)
        {
            byte[] newMessage = serializer.MakeSerialize(chatMessage);
            ClientDataset findClientDataset = clientDatasets.Find(с => с.clientInfo.Id == chatMessage.ReceiverId);
            findClientDataset.clientObject.client.Send(newMessage);
        }
        
        public void СlientSignInOutMessage(string ClientName, int Id, int actionId) 
        {
            ActionWithClientMessage actionWithClientMessage = new ActionWithClientMessage(DateTime.Now, servIp, port, ClientName, Id, actionId);
            BroadcastMessage(actionWithClientMessage);
        }

        public static IPAddress GetIp()
        {
            string host = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostEntry(host).AddressList;
            int i = 0;
            foreach (var address in addresses)
            {
                if (address.GetAddressBytes().Length == 4)
                {
                    i++;
                    if (i==2)
                    return address;
                }
            }
            return null;
        }

        public void ReceiveUdpMessage(Message message)
        {
            if (message is FindServerRequestMessage)
            {
                FindServerRequestMessage clientUdpRequestMessage = (FindServerRequestMessage)message;
                FindServerRecieveMessage serverUdpAnswerMessage = new FindServerRecieveMessage(DateTime.Now, servIp, port);
                IPEndPoint clientEndPoint = new IPEndPoint(clientUdpRequestMessage.SenderIp, clientUdpRequestMessage.SenderPort);
                Socket serverUdpAnswerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                serverUdpAnswerSocket.SendTo(serializer.MakeSerialize(serverUdpAnswerMessage), clientEndPoint);
            }
        }

        public void AddChatRoomMessageToList(ChatMessage chatMessage)
        {
            clientDatasets[0].clientInfo.MessageHistory.Add(chatMessage);
        }

    }
}
