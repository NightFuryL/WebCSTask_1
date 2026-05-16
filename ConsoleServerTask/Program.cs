using System.Net;
using System.Net.Sockets;
using System.Text;
namespace ConsoleServerTask;
public class Program
{
    private static Socket _server;
    private static int localPort = 9999;
    private static EndPoint localEp;
    private static IPAddress localIp;
    private static List<EndPoint> clients = new();
    private static int secretNumber;
    static async Task Main(string[] args)
    {
        Random random = new Random();
        secretNumber = random.Next(1, 101);
        Console.WriteLine($"[SERVER] Secret number: {secretNumber}");
        localIp = IPAddress.Any;
        localEp = new IPEndPoint(localIp, localPort);
        _server = new Socket(
            AddressFamily.InterNetworkV6,
            SocketType.Dgram,
            ProtocolType.Udp);
        _server.DualMode = true;
        _server.Bind(localEp);
        clients = new List<EndPoint>();
        while (true)
        {
            byte[] buffer = new byte[4096];
            EndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
            SocketReceiveFromResult result = await _server.ReceiveFromAsync(buffer, remoteEp);
            string message =
                Encoding.UTF8.GetString(
                    buffer,
                    0,
                    result.ReceivedBytes);
            Console.WriteLine($"[LOG] {result.RemoteEndPoint}: {message}");
            bool exists = clients.Any(
                x => x.ToString() ==
                result.RemoteEndPoint.ToString());
            if (!exists)
                clients.Add(result.RemoteEndPoint);
                Console.WriteLine(
                    $"[SERVER] New player: {result.RemoteEndPoint}");
            if (message == "LEFT")
            {
                clients.RemoveAll(
                    x => x.ToString() ==
                    result.RemoteEndPoint.ToString());

                Console.WriteLine(
                    $"[SERVER] Player left: {result.RemoteEndPoint}");

                continue;
            }
            int number;
            if (!int.TryParse(message, out number))
            {
                continue;
            }
            string answer = "";
            if (number < secretNumber)
            {
                answer = "Too small";
            }
            else if (number > secretNumber)
            {
                answer = "Too big";
            }
            else
            {
                answer = "You win!";
            }
            byte[] answerData = Encoding.UTF8.GetBytes(answer);
            ArraySegment<byte> answerBuffer = new ArraySegment<byte>(answerData);
            await _server.SendToAsync(answerBuffer, result.RemoteEndPoint);
            if (number == secretNumber)
            {
                string winnerMessage = $"Player {result.RemoteEndPoint} won!";
                byte[] winnerData = Encoding.UTF8.GetBytes(winnerMessage);
                ArraySegment<byte> winnerBuffer = new ArraySegment<byte>(winnerData);
                foreach (EndPoint client in clients)
                {
                    await _server.SendToAsync(
                        winnerBuffer,
                        client);
                }
                Console.WriteLine("[SERVER] Game over");
                break;
            }
        }
        _server.Close();
    }
}