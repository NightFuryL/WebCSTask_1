using System.Net;
using System.Net.Sockets;
using System.Text;
using LibraryServer;

namespace UdpChatClient;
//Ще виріщив проблему з виводом тексту, помучався із синхронізацією чату
internal class Program
{
    private static object _lockObj = new();

    private static IPAddress _remoteIp;
    private static int _remotePort;
    private static int _localPort;

    private static string _userName;
    private static ConsoleColor _myColor;

    static void Main(string[] args)
    {
        Console.Write("Remote IP: ");
        _remoteIp = IPAddress.Parse(Console.ReadLine()!);

        Console.Write("Remote Port: ");
        _remotePort = int.Parse(Console.ReadLine()!);

        Console.Write("Local Port: ");
        _localPort = int.Parse(Console.ReadLine()!);

        Console.Write("User Name: ");
        _userName = Console.ReadLine()!;

        Console.Write("Color (0-15): ");
        //Зроби через числа так як це звичайний enum
        _myColor = (ConsoleColor)int.Parse(Console.ReadLine()!);

        _ = Task.Run(ReceiveData);

        while (true)
        {
            lock (_lockObj)
            {
                Console.ForegroundColor = _myColor;
                Console.Write("Message: ");
                Console.ResetColor();
            }

            string text = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(text))
            {
                ChatMessage message = new ChatMessage
                {
                    UserName = _userName,
                    Text = text,
                    Color = _myColor
                };

                SendData(message);
            }
        }
    }

    private static void ReceiveData()
    {
        try
        {
            using UdpClient udpClient = new UdpClient(_localPort);

            while (true)
            {
                IPEndPoint remoteEp = null!;

                byte[] data = udpClient.Receive(ref remoteEp);

                string json = Encoding.UTF8.GetString(data);

                ChatMessage? message = ChatMessage.FromJson(json);

                if (message != null)
                {
                    lock (_lockObj)
                    {
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

                        Console.ForegroundColor = message.Color;

                        Console.WriteLine(message);

                        Console.ResetColor();

                        Console.ForegroundColor = _myColor;
                        Console.Write("Message: ");
                        Console.ResetColor();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void SendData(ChatMessage message)
    {
        try
        {
            using UdpClient udpClient = new UdpClient();

            string json = message.ToJson();

            byte[] buffer = Encoding.UTF8.GetBytes(json);

            IPEndPoint remoteEp =
                new IPEndPoint(_remoteIp, _remotePort);

            udpClient.Send(buffer, buffer.Length, remoteEp);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}