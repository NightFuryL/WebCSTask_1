using MulticastLibrary;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace MulticastServer;
public partial class FormServer : Form
{
    private UdpClient _udpClient = new();

    private IPAddress _multicastIp = IPAddress.Parse("239.0.0.1");

    private int _port = 5000;

    public FormServer()
    {
        InitializeComponent();
    }
    private void FormServer_Load(object sender, EventArgs e)
    {
        cmbType.DataSource = Enum.GetValues(typeof(MessageType));
    }
    private async void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            CompanyMessage msg = new()
            {
                Text = txtMessage.Text,
                Type = (MessageType)cmbType.SelectedItem
            };

            string json = msg.ToJson();

            byte[] data = Encoding.UTF8.GetBytes(json);

            await _udpClient.SendAsync(
                data,
                data.Length,
                new IPEndPoint(
                    _multicastIp,
                    _port));

            txtLog.AppendText(msg + Environment.NewLine);
            txtMessage.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

}