using MulticastLibrary;

namespace MulticastLibrary;

public class MessageManager
{
    public event Action<CompanyMessage>? OnMessageAccepted;

    private List<MessageType> _subscriptions = new();

    public void Subscribe(MessageType type)
    {
        if (!_subscriptions.Contains(type))
        {
            _subscriptions.Add(type);
        }
    }

    public void Unsubscribe(MessageType type)
    {
        if (_subscriptions.Contains(type))
        {
            _subscriptions.Remove(type);
        }
    }

    public void ProcessMessage(CompanyMessage msg)
    {
        if (msg.Type == MessageType.Emergency)
        {
            OnMessageAccepted?.Invoke(msg);
            return;
        }

        if (_subscriptions.Contains(msg.Type))
        {
            OnMessageAccepted?.Invoke(msg);
        }
    }
}