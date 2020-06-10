using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client
{
    class FileManager
    {
        public string GetFileFolder()
        {
            string fileFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RecievedFiles");
            return fileFolder;
        }
        public string GetFilename(ref int offset, ref byte[] buffer, out long byteSize)
        {
            byteSize = BitConverter.ToInt64(buffer, offset);
            offset += sizeof(long);
            int filenameLength = BitConverter.ToInt32(buffer, offset);
            offset += sizeof(int);
            string filename = Encoding.UTF8.GetString(buffer, offset, filenameLength);
            offset += filenameLength;
            byteSize += offset;
            filename = filename.Substring(0, filename.IndexOf('.')) + "_" + DateTime.Now.ToString("HHmmss") + filename.Substring(filename.IndexOf('.'));
            return filename;
        }
        public byte[] GetDetailAboutFile(string filePath)
        {
            int startIndexOfName = filePath.LastIndexOf("\\") + 1;
            string filename = filePath.Substring(startIndexOfName);
            byte[] filenameByte = Encoding.UTF8.GetBytes(filename);
            byte[] fileDetail = new byte[sizeof(long) + sizeof(int) + filenameByte.Length];
            byte[] filesize = BitConverter.GetBytes(new FileInfo(filePath).Length);
            byte[] filenameLen = BitConverter.GetBytes(filenameByte.Length);
            filesize.CopyTo(fileDetail, 0);
            filenameLen.CopyTo(fileDetail, sizeof(long));
            filenameByte.CopyTo(fileDetail, sizeof(long) + sizeof(int));
            return fileDetail;
        }
    }
}
