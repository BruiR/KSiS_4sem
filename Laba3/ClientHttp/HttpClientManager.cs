using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;


namespace ClientHttp
{
    public class HttpClientManager
    {
        public long sizeOfLoadedFiles = 0;
        public Dictionary<int, string> LoadedFiles;
        private HttpClient httpClient;
        private const string HttpServerUrl = "http://localhost:10009/";
        private const long FileSizeLimit = 1024 * 1024 * 5;
        private const long AllFilesSizeLimit = 1024 * 1024 * 10;
        private List<string> FileExtensionList = new List<string>() { ".txt", ".pdf", ".png", ".doc", ".docx"};


        public HttpClientManager()
        {
            httpClient = new HttpClient();
            LoadedFiles = new Dictionary<int, string>();
        }

        public bool CheckFileRestrictions(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            var fileInfo = new FileInfo(filePath);
            long fileSize = fileInfo.Length;
            if ((sizeOfLoadedFiles + fileSize < AllFilesSizeLimit) && (fileSize < FileSizeLimit) && (FileExtensionList.Contains(extension)))
            {
                sizeOfLoadedFiles += fileSize;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> LoadFile(string filePath)
        {
            string originalfileName = Path.GetFileName(filePath);
            int fileId;
            do
            {
                string fileName = DateTime.Now.ToString("HHmmss") + "_" + originalfileName;
                var httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = HttpMethod.Post;
                httpRequestMessage.RequestUri = new Uri(HttpServerUrl + fileName);
                byte[] filecontent;
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    filecontent = new byte[fileStream.Length];
                    fileStream.Read(filecontent, 0, filecontent.Length);
                }
                var memoryStream = new MemoryStream(filecontent); 
                httpRequestMessage.Content = new StreamContent(memoryStream);
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                string fileIdStr = await httpResponseMessage.Content.ReadAsStringAsync();
                fileId = int.Parse(fileIdStr);
            } while (fileId == -1);
            return fileId;
        }



        public async void DeleteFile(int fileId)
        {
            LoadedFiles.Remove(fileId);
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Delete;
            httpRequestMessage.RequestUri = new Uri(HttpServerUrl + fileId);
            await httpClient.SendAsync(httpRequestMessage);
        }

        public void GetFileToSave(int fileId, string fileName)
        {           
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(HttpServerUrl + fileId);
            HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                byte[] FileContent = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
                using (var fileStream = new FileStream(fileName, FileMode.Create))
                {
                    fileStream.Write(FileContent, 0, FileContent.Length);
                }
            }
        }

        public async Task<string[]> GetFileInformation(int fileId)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Head;
            httpRequestMessage.RequestUri = new Uri(HttpServerUrl + fileId);
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string[] Info = new string[2];
                var fileName = httpResponseMessage.Headers.GetValues("fileName");
                string requestedFileName = fileName.First();
                int startIndexOfName = requestedFileName.IndexOf("_") + 1;
                requestedFileName = requestedFileName.Substring(startIndexOfName);
                var fileSize = httpResponseMessage.Headers.GetValues("fileSize");
                Info[0] = requestedFileName;
                Info[1] = fileSize.First();
                return Info;
            }
            return null;
        }
    }

}
