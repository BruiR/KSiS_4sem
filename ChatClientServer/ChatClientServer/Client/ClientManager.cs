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

namespace Client
{
    public class ClientManager
    {
        public const string host = "127.0.0.1";
        public const int port = 8081;
        public static Socket clientSocket;
        public static byte[] check = new byte[256];
        static MainForm f1;
        public static string UserName;
        public string fileFolderName;
        public bool registerMode;
        public ClientManager(MainForm mainf)
        {
            f1 = mainf;
        }

        FileManager fileManager = new FileManager();

        public void Connect()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(host), port);
            try
            {
                clientSocket.Connect(ipPoint);
            }
            catch
            {
                MessageBox.Show("Ошибка связи с сервером");
                Disconnect();
            }
        }

        public void ConnectToChat() 
        {
            try
            {
                Thread receiveThread = new Thread(new ThreadStart(Receive));
                receiveThread.Start();
            }
            catch
            {
                MessageBox.Show("Ошибка связи с сервером");
                Disconnect();
            }
        }
        public void Disconnect()
        {
            if (clientSocket != null) 
            {
                clientSocket.Close();
            }                
            Environment.Exit(0);
        }

        public void SendMessage(string MessageText) 
        {
            string message = '0' + UserName + ":" + MessageText;
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
        }

        public void SendStickerMessage(string stickerCode)
        {
            string message = '5' + stickerCode + UserName;
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
        }

        public void SendFile(string path) 
        {
            byte[] fileDetail = fileManager.GetDetailAboutFile(path);
            clientSocket.Send(Encoding.UTF8.GetBytes("1"));
            clientSocket.Send(fileDetail);
            clientSocket.SendFile(path);
        }

        public void SendFileNew(string path) 
        {
        }

        public void Receive()
        {
            DirectoryInfo directoryInfo = Directory.CreateDirectory(fileManager.GetFileFolder() + '\\' + UserName);
            fileFolderName = directoryInfo.FullName;

            while (true)
            {
                try
                {
                    byte[] data = new byte[256];
                    int bytes = 0;
                    bytes = clientSocket.Receive(data, data.Length, 0);
                    StringBuilder builder = new StringBuilder();
                    builder.Append(Encoding.UTF8.GetString(data, 0, 1));
                    if (builder.ToString() == "0")
                    {
                        ReceiveMessage(ref data, bytes);
                    }
                    if (builder.ToString() == "1") 
                    {
                        ReceiveFile(ref data, bytes);
                    }
                    if (builder.ToString() == "4") 
                    {
                        ChangeOnline(ref data, bytes);
                    }
                    if (builder.ToString() == "5")
                    {
                        ReceiveSticker(ref data, bytes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка связи с сервером");
                    MessageBox.Show(ex.ToString());
                    Disconnect();
                }
            }
        }
        private  static void ReceiveSticker(ref byte[] data, int bytes) 
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builderName = new StringBuilder();
            builder.Append(Encoding.UTF8.GetString(data, 1, 1));
            builderName.Append(Encoding.UTF8.GetString(data, 2, bytes - 2));
            f1.BeginInvoke((MethodInvoker)(() => f1.RedrawSticker(builder.ToString(), builderName.ToString())));
        }

        private static void ReceiveMessage(ref byte[] data, int bytes)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Encoding.UTF8.GetString(data, 1, bytes - 1));

            while (clientSocket.Available > 0)
            {
                try 
                { 
                    bytes = clientSocket.Receive(data, data.Length, 0); 
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.ToString()); 
                }
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            f1.RedrawOther(builder.ToString());

        }

        public void ReceiveFile(ref byte[] data, int bytes)
        {
            try
            {
                int maxFileSize = 10;
                byte[] buffer = new Byte[1024 * 1024 * maxFileSize];
                int receivedBytes = 0;
                try
                {
                    receivedBytes = clientSocket.Receive(buffer);
                }
                catch { }
                int offset = 0;
                long bytesSize;
                string filename = fileManager.GetFilename(ref offset, ref buffer, out bytesSize);
                string filepath = Path.Combine(fileFolderName, filename);
                BinaryWriter binWriter = new BinaryWriter(File.Open(filepath, FileMode.Create));
                binWriter.Write(buffer, offset, receivedBytes - offset);
                while ((bytesSize -= receivedBytes) > 0)
                {
                    try
                    {
                        receivedBytes = clientSocket.Receive(buffer);
                    }
                    catch { }
                    if (receivedBytes != 0)
                    {
                        binWriter.Write(buffer, 0, receivedBytes);
                    }
                }
                binWriter.Close();
                f1.IsFilesListboxUpdate = true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool SendSignUpData(string Name, string UserPass)
        {
            try 
            { 
                string message = '3' + Name + ":" + UserPass;
                byte[] data = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(data);
                byte[] resultData = new byte[256];
                int bytes;
                bytes = clientSocket.Receive(resultData, resultData.Length, 0);
                MessageBox.Show(" Сообщение получено ");
                StringBuilder builder = new StringBuilder();
                StringBuilder builderName = new StringBuilder();
                builder.Append(Encoding.UTF8.GetString(resultData, 0, 2));
                builderName.Append(Encoding.UTF8.GetString(resultData, 2, bytes - 2));
                if ((builder.ToString() == "30") && (builderName.ToString() == Name))
                {
                    MessageBox.Show(" Ошибка регистрации. ");
                    return false;
                }
                if ((builder.ToString() == "31") && (builderName.ToString() == Name))
                {
                    UserName = Name;
                    MessageBox.Show(" Успешно зарегестрировались и вошли. ");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public bool SendSignInData(string Name, string UserPass)
        {
            try
            {
                string message = '2' + Name + ":" + UserPass;
                byte[] data = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(data);
                byte[] resultData = new byte[256];
                int bytes = 0;
                bytes = clientSocket.Receive(resultData, resultData.Length, 0);
                StringBuilder builder = new StringBuilder();
                StringBuilder builderName = new StringBuilder();
                builder.Append(Encoding.UTF8.GetString(resultData, 0, 2));
                builderName.Append(Encoding.UTF8.GetString(resultData, 2, bytes - 2));
                if ((builder.ToString() == "20") && (builderName.ToString() == Name))
                {
                    MessageBox.Show(" Ошибка входа. ");
                    return false;
                }
                if ((builder.ToString() == "21") && (builderName.ToString() == Name))
                {
                    MessageBox.Show(" Успешно вошли. ");
                    UserName = Name;
                    return true;
                }
                return false;            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        private static void ChangeOnline(ref byte[] data, int bytes) 
        {
            OnlineListboxHandler handler = new OnlineListboxHandler();
            StringBuilder builder = new StringBuilder();
            StringBuilder actionBuilder = new StringBuilder();
            actionBuilder.Append(Encoding.UTF8.GetString(data, 0, 2));
            builder.Append(Encoding.UTF8.GetString(data, 3, bytes - 3));
            while (clientSocket.Available > 0)
            {
                try { bytes = clientSocket.Receive(data, data.Length, 0); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            if (actionBuilder.ToString() == "41")
            {
                handler.UpdatePeople(f1, builder.ToString());
            }
            if (actionBuilder.ToString() == "42")
            {
                handler.RemoveHuman(f1, builder.ToString());
            }
            if (actionBuilder.ToString() == "43")
            {
                handler.AddHuman(f1, builder.ToString());
            }
        }
    }
}
