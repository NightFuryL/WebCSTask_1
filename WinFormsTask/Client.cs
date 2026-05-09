using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormsTask
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            using Socket client = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            client.DualMode = true; //для IPv6 та IPv4, головне - AddressFamily.InterNetworkV6
            try
            {
                string message = txtMessage.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);

                IPAddress remoteIP = IPAddress.Loopback;
                int remotePort = 9999;
                EndPoint remoteEp = new IPEndPoint(remoteIP, remotePort);

                ArraySegment<byte> dataBuffer = new ArraySegment<byte>(data, 0, data.Length);

                //client.SendToAsync(data, 0, data.Length, SocketFlags.None, remoteEp);
                await client.SendToAsync(dataBuffer, remoteEp);
                byte[] buffer = new byte[4096];

                //int bytesRead = client.ReceiveFrom(buffer, ref remoteEp);
                SocketReceiveFromResult result = await client.ReceiveFromAsync(buffer, remoteEp);

                string answer = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);//bytesRead);
                txtAsnwer.Text = answer;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"{ex.ToString}");
            }
            
        }
    }
}
