using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net.Http;


namespace ClientHttp
{
    public class HttpClientManager
    {
        public Dictionary<int, string> LoadedFiles;
        HttpClient client;
        const string ServerUri = "http://localhost:10009/"; 
        const long FileSizeLimit = 52428800; 
        const long AllFilesSizeLimit = 104857600; 
        List<string> FileExtensionList = new List<string>() { ".txt", ".pdf", ".png", ".doc", ".docx"};
        public long SizeOfLloadedFiles = 0;


        public HttpClientManager()
        {
            client = new HttpClient();
            LoadedFiles = new Dictionary<int, string>();
        }

        public bool CheckFileRestrictions(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            FileInfo fileInfo = new FileInfo(filePath);
            long fileSize = fileInfo.Length;
            if ((SizeOfLloadedFiles + fileSize < AllFilesSizeLimit) && (fileSize < FileSizeLimit) && (FileExtensionList.Contains(extension)))
            {
                SizeOfLloadedFiles += fileSize;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> LoadFile(string filePath)
        {
            string OriginalfileName = Path.GetFileName(filePath);
            int fileId;
            do
            {
                string fileName = DateTime.Now.ToString("HHmmss") + "_" + OriginalfileName;
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, ServerUri);
                httpRequestMessage.Content = ProcessTheFile(filePath);
                httpRequestMessage.Headers.Add("FileName", fileName);
                HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
                string fileIdStr = await httpResponseMessage.Content.ReadAsStringAsync();
                fileId = int.Parse(fileIdStr);
            } while (fileId == -1);
            return fileId;
        }

        public MultipartFormDataContent ProcessTheFile(string filePath)
        {
            byte[] buffer;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
            }
            ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent);
            return multipartFormDataContent;
        }

        public async void DeleteFile(int fileId)
        {
            LoadedFiles.Remove(fileId);
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, ServerUri + fileId);
            await client.SendAsync(httpRequestMessage);

        }

        public async Task<byte[]> GetFileToSave(int fileId)
        {
            byte[] requestedFileContent;
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, ServerUri + fileId);
            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                requestedFileContent = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                return requestedFileContent;
            }
            return null;
        }

        public async Task<string[]> GetFileInformation(int fileId)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Head, ServerUri + fileId);
            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string[] Info = new string[2];
                var fileName = httpResponseMessage.Headers.GetValues("FileName");
                string requestedFileName = fileName.First();
                int startIndexOfName = requestedFileName.IndexOf("_") + 1;
                requestedFileName = requestedFileName.Substring(startIndexOfName);
                var fileSize = httpResponseMessage.Headers.GetValues("FileSize");
                //IEnumerable<String>
                Info[0] = requestedFileName;
                Info[1] = fileSize.First();
                return Info;
            }
            return null;
        }
    }

}
