using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress localIp = IPAddress.Any;
            int localPort = 9999;
            EndPoint localEp = new IPEndPoint(localIp, localPort);
            using Socket server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);

            server.Bind(localEp);

            while (true)
            {
                byte[] buffer = new byte[4098];

                EndPoint? remoteEp = new IPEndPoint(IPAddress.Any, 0);

                //int bytesRead = server.ReceiveFrom(buffer, ref remoteEp);
                SocketReceiveFromResult result = await server.ReceiveFromAsync(buffer, remoteEp);

                string message = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);

                Console.WriteLine($"[LOG] New data: {message}. Sender: {result.RemoteEndPoint}");

                string answer = "ECHO: " + message;
                byte[] data = Encoding.UTF8.GetBytes(answer);

                ArraySegment<byte> dataBuffer = new ArraySegment<byte>(data);
                
                Thread.Sleep(5000);

                await server.SendToAsync(data, result.RemoteEndPoint);
            }
        }
    }
}
