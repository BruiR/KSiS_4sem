using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace ServerHttp
{
    class Server
    {
        private Dictionary<int, string> filesDictionary;
        private int fileIdCounter = -1;
        private const int FailedId = -1;
        private const string SavePath = "E:/mysor/";
        private const string HttpListenerPrefix = "http://*:10009/";
        private const int NotFoundHttpStatusCode = 404;
        private const int OkHttpStatusCode = 200;
        public Server()
        {
            filesDictionary = new Dictionary<int, string>();
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

        public void Listening()
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add(HttpListenerPrefix);
            httpListener.Start();
            Console.WriteLine("Сервер HTTP запущен");
            while (true)
            {
                HttpListenerContext httpListenerContext = httpListener.GetContext();
                SelectMethod(httpListenerContext);
            }
        }


        private void GetRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            Console.WriteLine("Запрос на скачивание. Файл с Id  : " + fileId);
            if (filesDictionary.ContainsKey(fileId))
            {
                byte[] fileContent;
                httpListenerContext.Response.StatusCode = OkHttpStatusCode;
                string filePath = SavePath + filesDictionary[fileId];
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    fileContent = new byte[fileStream.Length];
                    fileStream.Read(fileContent, 0, (int)fileStream.Length);
                }
                httpListenerContext.Response.ContentLength64 = fileContent.Length;
                httpListenerContext.Response.OutputStream.Write(fileContent, 0, fileContent.Length);
            }
            else
            {
                httpListenerContext.Response.StatusCode = NotFoundHttpStatusCode;
            }
            httpListenerContext.Response.OutputStream.Close();
        }

        private void HeadRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            if (filesDictionary.ContainsKey(fileId))
            {
                httpListenerContext.Response.StatusCode = OkHttpStatusCode;
                httpListenerContext.Response.Headers.Add("fileName", filesDictionary[fileId]);

                string filePath = SavePath + filesDictionary[fileId];
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                long fileSize = fileStream.Length;
                fileStream.Close();
                httpListenerContext.Response.Headers.Add("fileSize", fileSize.ToString());
            }
            else
            {
                httpListenerContext.Response.StatusCode = NotFoundHttpStatusCode;
            }
            httpListenerContext.Response.OutputStream.Close();
        }

        private string SaveFile(string fileName, byte[] fileContent)
        {
            string filePath = SavePath + fileName;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(fileContent, 0, fileContent.Length);
            }
            fileIdCounter++;
            filesDictionary.Add(fileIdCounter, fileName);
            return fileIdCounter.ToString();
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



        private void PostRequest(HttpListenerContext httpListenerContext)
        {
            string fileName = httpListenerContext.Request.Url.LocalPath.Substring(1);
            if (CheckNameForUniqueness(fileName))
            {
                byte[] fileContent = new byte[httpListenerContext.Request.ContentLength64];
                httpListenerContext.Request.InputStream.Read(fileContent, 0, (int)httpListenerContext.Request.ContentLength64);
                string thisFileId = SaveFile(fileName, fileContent);
                httpListenerContext.Response.OutputStream.Write(Encoding.UTF8.GetBytes(thisFileId), 0, Encoding.UTF8.GetBytes(thisFileId).Length);
                Console.WriteLine("Загружен файл " + fileName + " Id =  " + thisFileId.ToString());
            }
            else
            {
                httpListenerContext.Response.OutputStream.Write(Encoding.UTF8.GetBytes(FailedId.ToString()), 0, Encoding.UTF8.GetBytes(FailedId.ToString()).Length);
                Console.WriteLine("Файл уже существует : " + fileName );
            }
            httpListenerContext.Response.OutputStream.Close();
        }


        private void DeleteRequest(HttpListenerContext httpListenerContext)
        {
            int fileId = int.Parse(httpListenerContext.Request.Url.LocalPath.Substring(1));
            if (filesDictionary.ContainsKey(fileId))
            {
                httpListenerContext.Response.StatusCode = OkHttpStatusCode;
                string filePath = SavePath + filesDictionary[fileId];
                filesDictionary.Remove(fileId);
                File.Delete(filePath);
                Console.WriteLine("Файл удален. Id = " + fileId);
            }
            else
            {
                httpListenerContext.Response.StatusCode = NotFoundHttpStatusCode;
            }
            httpListenerContext.Response.OutputStream.Close();
        }


    }
}
