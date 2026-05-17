using MulticastLibrary;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MulticastClient;
//UdpReceiveResult звичайна структура результата в якості повернення метода ReceiveAsync

public partial class FormClient : Form
{
    private UdpClient _udpClient = null!;
    private MessageManager _messageManager = new();
    private IPAddress _multicastIp = IPAddress.Parse("239.0.0.1");
    private int _port = 5000;
    public FormClient()
    {
        InitializeComponent();
    }

    private void FormClient_Load(object sender, EventArgs e)
    {
        //Подивився в інтернеіт як прибрати якесь значення Enum та повернути новий без нього
        clbTypes.DataSource = Enum.GetValues(typeof(MessageType))
                                .Cast<MessageType>() 
                                .Where(val => val != MessageType.Emergency) 
                                .ToList(); 
        _messageManager.OnMessageAccepted += AddMessage;
        _messageManager.Subscribe(MessageType.Emergency);
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        try
        {
            _udpClient = new UdpClient();
            _udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _udpClient.Client.Bind(new IPEndPoint( IPAddress.Any, _port));
            _udpClient.JoinMulticastGroup(_multicastIp);
            UpdateSubscriptions();
            _ = Task.Run(ReceiveMessages);
            MessageBox.Show("Connected");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void UpdateSubscriptions()
    {
        foreach (MessageType type in Enum.GetValues(typeof(MessageType)))
        {
            if (type != MessageType.Emergency)
            {
                _messageManager.Unsubscribe(type);
            }
        }

        foreach (object item in clbTypes.CheckedItems)
        {
            _messageManager.Subscribe((MessageType)item);
        }

        _messageManager.Subscribe(MessageType.Emergency);
    }

    private async Task ReceiveMessages()
    {
        while (true)
        {
            try
            {
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                string json = Encoding.UTF8.GetString( result.Buffer);
                CompanyMessage? msg = CompanyMessage.FromJson(json);
                if (msg != null)
                {
                    _messageManager.ProcessMessage(msg);
                }
            }
            catch
            {
                break;
            }
        }
    }
    private void AddMessage(CompanyMessage msg)
    {
        if (InvokeRequired)
        {
            Invoke(() => AddMessage(msg));
            return;
        }
        txtLog.AppendText(msg + Environment.NewLine);
    }

    private void clbTypes_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        BeginInvoke(() =>
        {
            UpdateSubscriptions();
        });
    }

    private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            _udpClient?.DropMulticastGroup(_multicastIp);
            _udpClient?.Close();
        }
        catch
        {

        }
    }
}