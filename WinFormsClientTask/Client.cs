using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormsClientTask;

public partial class Client : Form
{
    private Socket _client;
    private int remotePort = 9999;
    private IPAddress remoteIp;
    private EndPoint remoteEp;

    public Client()
    {
        InitializeComponent();

        _client = new Socket(
            AddressFamily.InterNetworkV6,
            SocketType.Dgram,
            ProtocolType.Udp);
        _client.DualMode = true;

        remoteIp = IPAddress.Loopback;
        remoteEp = new IPEndPoint(remoteIp, remotePort);

        txtLog.Text += "Guess number from 0 to 100" + Environment.NewLine;
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string message = txtNumber.Text;

            byte[] data = Encoding.UTF8.GetBytes(message);

            ArraySegment<byte> dataBuffer = new ArraySegment<byte>(data);

            await _client.SendToAsync(dataBuffer, remoteEp);

            byte[] buffer = new byte[4096];

            SocketReceiveFromResult result = await _client.ReceiveFromAsync(buffer, remoteEp);

            string answer = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);

            txtLog.AppendText(answer + Environment.NewLine);

            SocketReceiveFromResult result2 = await _client.ReceiveFromAsync(buffer, remoteEp);

            string gameResult = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);

            txtLog.AppendText(gameResult + Environment.NewLine);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

    }

    private async void Client_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            if(_client != null && _client.Connected)
            {
                ArraySegment<byte> dataBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("LEFT"));
                await _client.SendToAsync(dataBuffer, remoteEp);
                _client.Close();
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"ERROR: {ex.Message}", "Closing error");
        }
    }
}
