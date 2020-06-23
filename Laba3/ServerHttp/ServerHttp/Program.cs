using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpServer = new Server();
            httpServer.Listening();
            Console.ReadLine();
        }
    }
}
