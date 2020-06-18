using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ChatHelpingLibrary
{
    public class Serializer
    {
        public Message MakeDeserialize(byte[] data)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (Message)binaryFormatter.Deserialize(memoryStream);
            }
        }

        public byte[] MakeSerialize(Message message)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, message);
                return memoryStream.ToArray();
            }
        }

    }
}
