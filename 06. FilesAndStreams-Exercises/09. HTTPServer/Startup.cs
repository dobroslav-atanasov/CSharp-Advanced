namespace _09._HTTPServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class Startup
    {
        public const int Port = 8000;
        public const string HtmlfilePath = @"..\..\page";

        public static void Main()
        {
            IPAddress localAdress = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localAdress, Port);
            tcpListener.Start();
            Console.WriteLine($"Waiting for a connection on {localAdress}:{Port} ... ");

            while (true)
            {
                NetworkStream networkStream = tcpListener.AcceptTcpClient().GetStream();
                using (networkStream)
                {
                    byte[] request = new byte[4096];
                    int readBytes = networkStream.Read(request, 0, request.Length);
                    string requestDetails = Encoding.UTF8.GetString(request, 0, readBytes);
                    Console.WriteLine(requestDetails);

                    string[] requestFirstLine = requestDetails.Substring(0, requestDetails.IndexOf(Environment.NewLine)).Split();
                    string url = requestFirstLine[1];
                    string headerStatus = $"{requestFirstLine[2]} 200 OK";
                    string requestedPage = string.Empty;

                    if (url == "/")
                    {
                        requestedPage = $"{HtmlfilePath}/index.html";
                    }
                    else
                    {
                        requestedPage = $"{HtmlfilePath}{url.Substring(url.IndexOf('/'))}";
                        if (!requestedPage.EndsWith(".html"))
                        {
                            requestedPage += ".html";
                        }
                        if (!File.Exists(requestedPage))
                        {
                            requestedPage = $"{HtmlfilePath}/error.html";
                        }
                        else
                        {
                            headerStatus = "HTTP/1.0 404 Not Found";
                        }
                    }

                    StringBuilder header = new StringBuilder();
                    header.Append($"{headerStatus}{Environment.NewLine}");
                    header.Append($"Accept-Ranges: bytes{Environment.NewLine}");

                    StringBuilder message = new StringBuilder();
                    StreamReader reader = new StreamReader(requestedPage);
                    using (reader)
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            message.Append(line);
                            line = reader.ReadLine();
                        }
                    }

                    if (requestedPage.EndsWith("info.html"))
                    {
                        message.Replace("{0}", DateTime.Now.ToString("ddd, MMM d, yyyy")).Replace("{1}", Environment.ProcessorCount.ToString());
                    }

                    int contentLength = Encoding.UTF8.GetBytes(message.ToString()).Length;
                    header.Append($"ContentLength: {contentLength}{Environment.NewLine}");
                    header.Append($"Connection: close{Environment.NewLine}");
                    header.Append($"Content-Type: text/html{Environment.NewLine}");
                    header.Append(Environment.NewLine);
                    message.Insert(0, header);

                    byte[] bytes = Encoding.UTF8.GetBytes(message.ToString());
                    networkStream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}