namespace _05._NetworkStreams
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class Startup
    {
        private const int PortNumber = 8080;

        public static void Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();
            Console.WriteLine($"Listening on port {PortNumber}");

            while (true)
            {
                NetworkStream stream = tcpListener.AcceptTcpClient().GetStream();
                using (stream)
                {
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, 4096);
                    Console.WriteLine(Encoding.UTF8.GetString(request, 0, readBytes));
                    string html = $"<html><body><h1>Welcome to my awesome site! - {DateTime.Now}<h1><body><html>";
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }
        }
    }
}