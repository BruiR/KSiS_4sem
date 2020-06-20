using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Web;
using System.IO;

namespace ServerHttp
{
    class Server
    {
        HttpListener httpListener;
        Dictionary<int, string> filesDictionary = new Dictionary<int, string>();
        int fileIdCounter = -1;
        const int failed = -1;
        const string savePath = "E:/mysor/";
        const string ServerPrefix = "http://*:10009/";

        public Server()
        {
            httpListener = new HttpListener();
            Thread listeningThread = new Thread(Listening);
            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        private void SelectMethod(HttpListenerContext httpListenerContext)
        {
            Console.WriteLine("Получен запрос: метод " + httpListenerContext.Request.HttpMethod);
            switch (httpListenerContext.Request.HttpMethod)
            {
                case "POST":
                    PostRequest(httpListenerContext);
                    break;
                case "GET":
                    GetRequest(httpListenerContext);
                    break;
                case "HEAD":
                    HeadRequest(httpListenerContext);
                    break;
                case "DELETE":
                    DeleteRequest(httpListenerContext);
                    break;
            }
        }

        private void Listening()
        {
            httpListener.Prefixes.Add(ServerPrefix);
            httpListener.Start();
            Console.WriteLine("Сервер HTTP запущен");
            while (true)
            {
                HttpListenerContext httpListenerContext = httpListener.GetContext();
                SelectMethod(httpListenerContext);
            }
        }

        private bool CheckingForExistence(int fileId)
        {
            if (filesDictionary.ContainsKey(fileId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private byte[] GetFileContent(int fileId)
        {
            byte[] fileContent;
            string filePath = savePath + filesDictionary[fileId];
            using (FileStream fileToGetContent = new FileStream(filePath, FileMode.Open))
            {
                fileContent = new byte[fileToGetContent.Length];
                fileToGetContent.Read(fileContent, 0, (int)fileToGetContent.Length);
            }
            return fileContent;
        }

        private void GetRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            Console.WriteLine("Запрос на скачивание. Файл с Id  : " + fileId);
            if (CheckingForExistence(fileId))
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.OK;
                byte[] FileContent = GetFileContent(fileId);
                httpListenerContext.Response.OutputStream.Write(FileContent, 0, FileContent.Length);
            }
            else
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            httpListenerContext.Response.OutputStream.Close();
        }

        private void HeadRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            if (CheckingForExistence(fileId))
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.OK;
                httpListenerContext.Response.Headers.Add("FileName", filesDictionary[fileId]);

                string filePath = savePath + filesDictionary[fileId];
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                long fileSize = fileStream.Length;
                fileStream.Close();
                httpListenerContext.Response.Headers.Add("FileSize", fileSize.ToString());
            }
            else
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            httpListenerContext.Response.OutputStream.Close();
        }


        private bool CheckNameForUniqueness(string fileName)
        {
            foreach (var file in filesDictionary)
            {
                if (fileName == file.Value) 
                {
                    return false;
                }
            }
            return true;
        }

        private byte[] GetFileContent(HttpListenerContext httpListenerContext)
        {
            StreamReader streamReader = new StreamReader(httpListenerContext.Request.InputStream, httpListenerContext.Request.ContentEncoding);
            string content = streamReader.ReadToEnd();
            return httpListenerContext.Request.ContentEncoding.GetBytes(content);
        }

        private string SaveFile(string fileName, byte[] fileContent)
        {
            string filePath = savePath + fileName;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(fileContent, 0, fileContent.Length);
            }
            fileIdCounter++;
            filesDictionary.Add(fileIdCounter, fileName);
            return fileIdCounter.ToString();
        }

        private void PostRequest(HttpListenerContext httpListenerContext)
        {
            string fileName = httpListenerContext.Request.Headers.Get("FileName");
            if (CheckNameForUniqueness(fileName))
            {
                byte[] fileContent = GetFileContent(httpListenerContext);
                string thisFileId = SaveFile(fileName, fileContent);
                httpListenerContext.Response.OutputStream.Write(Encoding.UTF8.GetBytes(thisFileId), 0, Encoding.UTF8.GetBytes(thisFileId).Length);
                Console.WriteLine("Загружен файл " + fileName + " Id =  " + thisFileId.ToString());
            }
            else
            {
                httpListenerContext.Response.OutputStream.Write(Encoding.UTF8.GetBytes(failed.ToString()), 0, Encoding.UTF8.GetBytes(failed.ToString()).Length);
                Console.WriteLine("Файл уже существует : " + fileName );
            }
            httpListenerContext.Response.OutputStream.Close();
        }


        private void DeleteRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            if (CheckingForExistence(fileId))
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.OK;
                string filePath = savePath + filesDictionary[fileId];
                filesDictionary.Remove(fileId);
                File.Delete(filePath);
                Console.WriteLine("Файл удален. Id = " + fileId);
            }
            else
            {
                httpListenerContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            httpListenerContext.Response.OutputStream.Close();
        }


    }
}
