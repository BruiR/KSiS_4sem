using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.OleDb;

namespace Chat
{
    enum Action { Message, File, SignIn, SignUp, OnlineUpdate, StickerMessage }

    class ClientObject
    {
        public string Id { get; private set; }
        public  string userName;
        public Socket client;
        static ServerObject server;
        static byte[] check = new byte[256];
        FileManager fileManager = new FileManager();

        public ClientObject(Socket tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
        }

        public bool CheckNewUser()
        {
            int bytes = 0;
            byte[] data = new byte[1024];
            bytes = client.Receive(data);
            Action action = (Action)(data[0] - 48);
            switch (action)
            {
                case Action.SignIn:
                    CheckSignIn(ref data, bytes);
                    break;
                case Action.SignUp:
                    CheckSignUp(ref data, bytes);
                    break;
            }
            return true;
        }
        public void Process()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        int bytes = 0;
                        byte[] data = new byte[1024];
                        bytes = client.Receive(data);
                        Action action = (Action)(data[0] - 48);
                        DefineAction(action, ref data, bytes);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }


        public void DefineAction(Action action, ref byte[] data, int bytes)
        {
            switch(action)
            {
                case Action.Message:
                    ReceiveMessage(ref data, bytes);
                    break;
                case Action.File:
                    ReceiveFile(ref data, bytes);
                    break;
                case Action.StickerMessage:
                    ReceiveStickerMessage(ref data, bytes);
                    break;
            }
        }
        
        private void ReceiveStickerMessage(ref byte[] data, int bytes) 
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Encoding.UTF8.GetString(data, 1, bytes - 1));
            while (client.Available > 0)
            {
                bytes = client.Receive(data, data.Length, 0);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            Console.WriteLine(builder.ToString());
            server.BroadcastMessage('5' + builder.ToString());
        }

        private void ReceiveMessage(ref byte[] data, int bytes)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Encoding.UTF8.GetString(data, 1, bytes - 1));
            while (client.Available > 0)
            {
                bytes = client.Receive(data, data.Length, 0);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            Console.WriteLine(builder.ToString());
            server.BroadcastMessage('0' + builder.ToString());
        }

        private void ReceiveFile(ref byte[] data, int bytes)
        {
            try
            {
                int maxFileSize = 10;
                byte[] buffer = new Byte[1024 * 1024 * maxFileSize];
                int receivedBytes = 0;
                try
                {
                    receivedBytes = client.Receive(buffer);
                }
                catch { }
                int offset = 0;
                long bytesSize;
                string filename = fileManager.getFilename(ref offset, ref buffer, out bytesSize);
                string filepath = Path.Combine(fileManager.GetFileFolder(), filename);
                BinaryWriter binWriter = new BinaryWriter(File.Open(filepath, FileMode.Create));
                binWriter.Write(buffer, offset, receivedBytes - offset);
                while ((bytesSize -= receivedBytes) > 0)
                {
                    try
                    {
                        receivedBytes = client.Receive(buffer);
                    }
                    catch { }
                    if (receivedBytes != 0)
                    {
                        binWriter.Write(buffer, 0, receivedBytes);
                    }
                }
                binWriter.Close();
                server.BroadcastFile(filepath);
                System.Threading.Thread.Sleep(1000);
                server.BroadcastMessage("0" + userName + ": загрузил файл : " + filename);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void SendFile(string path)
        {
            try
            { 
                byte[] fileDetail = fileManager.GetDetailAboutFile(path);
                client.Send(Encoding.UTF8.GetBytes("1"));
                client.Send(fileDetail);
                client.SendFile(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CheckSignIn(ref byte[] data, int bytes)
        {
            StringBuilder builder = new StringBuilder();
            string message = Encoding.UTF8.GetString(data, 1, bytes - 1);
            string[] split = message.Split(":".ToCharArray());
            userName = split[0];
            string userPassword = split[1];
            Console.WriteLine(" login = " + userName + " password = " + userPassword);
            string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UserDB.mdb;";
            OleDbConnection myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM UsersTable WHERE Name=userName AND Password=userPassword";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("userName", userName);
            command.Parameters.AddWithValue("userPassword", userPassword);
            if (command.ExecuteScalar() as int? == 1) 
            {
                try 
                { 
                    string outMessage = "21" + userName;
                    byte[] outData = Encoding.UTF8.GetBytes(outMessage);
                    client.Send(outData);                
                    string Mess = "43:" + userName;
                    server.BroadcastMessage(Mess);
                    server.AddConnection(this);
                    client.Send(Encoding.UTF8.GetBytes(CreateMesForUpdateChatOnline()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else 
            {
                string outMessage = "20" + userName;
                byte[] outData = Encoding.UTF8.GetBytes(outMessage);
                client.Send(outData);
                Console.WriteLine(" нет такого в бд");
                Close();
            }
            myConnection.Close();
        }

        private void CheckSignUp(ref byte[] data, int bytes)
        {
            StringBuilder builder = new StringBuilder();
            string message = Encoding.UTF8.GetString(data, 1, bytes - 1);
            string[] split = message.Split(":".ToCharArray());
            userName = split[0];
            string userPassword = split[1];
            Console.WriteLine(" login = " + userName + " parol = " + userPassword);
            string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UserDB.mdb;";
            OleDbConnection myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT COUNT(*) FROM UsersTable WHERE Name=userName";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("userName", userName);
            if (command.ExecuteScalar() as int? == 0)
            {
                try
                {
                    query = "INSERT INTO [UsersTable] ([Name], [Password]) VALUES (userName, userPassword)";
                    OleDbCommand command2 = new OleDbCommand(query, myConnection);
                    command2.Parameters.AddWithValue("userName", userName);
                    command2.Parameters.AddWithValue("userPassword", userPassword);
                    command2.ExecuteNonQuery();
                    string outMessage = "31" + userName;
                    byte[] outData = Encoding.UTF8.GetBytes(outMessage);
                    Console.WriteLine(" УРА! новый пользователь  зарегестрирован");
                    client.Send(outData);
                    string Mess = "43:" + userName;
                    server.BroadcastMessage(Mess);
                    server.AddConnection(this);
                    client.Send(Encoding.UTF8.GetBytes(CreateMesForUpdateChatOnline()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                string outMessage = "30" + userName;
                byte[] outData = Encoding.UTF8.GetBytes(outMessage);
                client.Send(outData);
                Console.WriteLine(" ОШИБКА, такой пользователь уже зарегестрирован");
                Close();
            }
            myConnection.Close();
        }

        public void Close()
        {
            if (client != null)
            {
                string outMessage = "42:" + userName;
                server.BroadcastMessage(outMessage);
                client.Close();
            }                
        }
        public string CreateMesForUpdateChatOnline() 
        {
            string peopleString ="";
            foreach (ClientObject AnotherOneClient in server.clients) 
            {
                peopleString += ':' + AnotherOneClient.userName;
            }
            string outMessage = "41" + peopleString;
            return outMessage;
        }
    }
}
