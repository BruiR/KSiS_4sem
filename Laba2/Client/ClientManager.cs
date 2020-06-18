using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatHelpingLibrary;

namespace Client
{
    public class ClientManager
    {
        //public const string host = "127.0.0.1";
        public const int port = 8081;
        public Socket clientTcpSocket;
        public Socket clientUdpSocket;
        public byte[] check = new byte[256];
        public MainForm f1;
        public string UserName;
        //public string fileFolderName;
        public bool registerMode;
        private Thread listenUdpThread;
        private Thread listenTcpThread;
        private Serializer serializer;
        public IPAddress clientIp;
        public int clientPort;
        public IPAddress ServerIp;
        public int ServerPort;
        public bool ServerInformation = false;
        public delegate void MessageHandler(ChatHelpingLibrary.Message message);
        public event MessageHandler ReceiveMessageHandler;
        public int MyId;

        public ClientManager(MainForm mainf)
        {
            f1 = mainf;
            listenTcpThread = new Thread(ListenTcp);
            listenUdpThread = new Thread(ListenUdp);
            clientTcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientUdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serializer = new Serializer();
        }

        public void ListenTcp()
        {
            byte[] data = new byte[1024];
            int bytesCounts;
            while (true) 
            {
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream()) 
                    { 
                        do
                        {
                            bytesCounts = clientTcpSocket.Receive(data);
                            memoryStream.Write(data, 0, bytesCounts);
                        } while (clientTcpSocket.Available > 0);

                        ChatHelpingLibrary.Message message = serializer.MakeDeserialize(memoryStream.ToArray());
                        ReceiveMessageHandler(message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "74");
                    Disconnect();
                    return;
                }
            }
        }

        public void ListenUdp()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint endPoint = ipEndPoint;
            int bytesCounts= 0;
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
                            bytesCounts = clientUdpSocket.ReceiveFrom(data, data.Length, SocketFlags.None, ref endPoint);
                            memoryStream.Write(data, 0, bytesCounts);
                        } while (clientUdpSocket.Available > 0);
                        if (bytesCounts > 0)
                        {
                            if (CheckUdpMessage(serializer.MakeDeserialize(memoryStream.ToArray())))
                            {
                                ServerInformation = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SendMessage(ChatMessage chatMessage)
        {
           clientTcpSocket.Send(serializer.MakeSerialize(chatMessage));
        }

        public bool CheckUdpMessage(ChatHelpingLibrary.Message message)
        {
            if (message is FindServerRecieveMessage)
            {
                FindServerRecieveMessage ServerInfoMessage = (FindServerRecieveMessage)message;
                ServerPort = ServerInfoMessage.SenderPort;
                ServerIp = ServerInfoMessage.SenderIp;
                return true;
            }
            return false; 
        }

        public void FindServer()
        {
            IPEndPoint broadcastIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 50000);
            IPEndPoint localIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            clientUdpSocket.EnableBroadcast = true;
            clientUdpSocket.Bind(localIpEndPoint);
            clientUdpSocket.SendTo(serializer.MakeSerialize(GetClientUdpRequestMessage()), broadcastIpEndPoint);
            listenUdpThread.Start();
        }

        private FindServerRequestMessage GetClientUdpRequestMessage()
        {
            IPEndPoint localIp = (IPEndPoint)clientUdpSocket.LocalEndPoint;
            return new FindServerRequestMessage(DateTime.Now, GetCurrrentHostIp(), localIp.Port);
        }
        public bool Connect(string Name)
        {
            UserName = Name;
            try
            {
                clientTcpSocket.Connect(ServerIp, ServerPort);
                listenTcpThread.Start();
                IPEndPoint ipEndPoint = (IPEndPoint)(clientTcpSocket.LocalEndPoint);
                HandshakeMessage handshakeMessage = new HandshakeMessage(DateTime.Now, ipEndPoint.Address, ipEndPoint.Port, UserName);
                clientTcpSocket.Send(serializer.MakeSerialize(handshakeMessage));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
                return false;
            }
        }

        public void Disconnect()
        {
            if (clientTcpSocket != null) 
            {
                clientTcpSocket.Close();
            }                
            Environment.Exit(0);
        }            

        public static IPAddress GetCurrrentHostIp()
        {
            string host = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostEntry(host).AddressList;
            int i = 0;
            foreach (var address in addresses)
            {
                if (address.GetAddressBytes().Length == 4)
                {
                    i++;
                    if (i == 2) 
                    {
                        return address;
                    }                        
                }
            }
            return null;
        }
    }
}
