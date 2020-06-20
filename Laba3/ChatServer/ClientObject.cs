using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.OleDb;
using ChatHelpingLibrary;

namespace Chat
{

    public class ClientObject
    {
        public int Id { get; set; }
        public  string userName;
        public Socket client;
        static ServerObject server;
        public Serializer serializer;
        public ClientDataset clientDataset;

        public ClientObject(Socket tcpClient, ServerObject serverObject)
        {
            clientDataset = new ClientDataset();
            serializer = new Serializer();
            client = tcpClient;
            server = serverObject;
        }
        public void ListenTcp()
        {
            byte[] data = new byte[1024];
            int bytesCounts;
            do
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    try
                    {
                        do
                        {
                            bytesCounts = client.Receive(data);
                            memoryStream.Write(data, 0, bytesCounts);
                        } while (client.Available > 0);
                        ChatHelpingLibrary.Message TcpMessage = serializer.MakeDeserialize(memoryStream.ToArray());
                        ReceiveMessageHandler(TcpMessage);
                    }
                    catch
                    {
                        Close();
                        break;
                    }
                }
            } while (true);
        }

        public void ReceiveMessageHandler(Message message) 
        {
            if (message is ChatMessage)
            {
                ChatMessage chatMessage = (ChatMessage)message;
                chatMessage.SenderId = Id;
                if (chatMessage.ReceiverId == 0)
                {
                    server.AddChatRoomMessageToList(chatMessage);
                    server.SendMessageToChatRoom(chatMessage, client);
                }
                else if (chatMessage.ReceiverId != 0)
                {
                    server.SendMessageToPrivateRoom(chatMessage, client);
                }
            }
            else 
            {
                Console.WriteLine("ListenTcp: пришло  сообщение не ChatMessage");
            }
        }

        public void WaitHandshakeMessage()
        {
            byte[] data = new byte[1024];
            int bytesCounts;
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    do
                    {
                        bytesCounts = client.Receive(data);
                        memoryStream.Write(data, 0, bytesCounts);
                    } while (client.Available > 0);
                    Message recievedMessage = serializer.MakeDeserialize(memoryStream.ToArray());
                    if (recievedMessage is HandshakeMessage)
                    {
                        HandshakeMessage handshakeMessage = (HandshakeMessage)recievedMessage;
                        clientDataset.clientObject = this;
                        clientDataset.clientInfo.Name = handshakeMessage.ClientName;
                        clientDataset.clientInfo.Id = server.id;
                        userName = handshakeMessage.ClientName;
                        Id = server.id;
                        Console.WriteLine("новый пользователь:" + handshakeMessage.ClientName + "   Id = " + clientDataset.clientInfo.Id.ToString());
                        server.id++;
                        server.AddConnection(clientDataset);
                        ListenTcp();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Close()
        {
            server.RemoveConnection(Id);
            if (client != null)
            {
                client.Close();
            }
            server.СlientSignInOutMessage(userName, Id, 0);
        }


    }
}
