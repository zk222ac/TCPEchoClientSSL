using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoClientSSL
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("localhost", 7000);

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns) {AutoFlush = true}; // enable automatic flushing
            for (int i = 0; i < 100; i++)
            {
                string message = "Secure socket Layer " + i;
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            Console.WriteLine("Client finished");
            // Console.ReadLine();
            ns.Close();
            clientSocket.Close();
        }
    }
}
