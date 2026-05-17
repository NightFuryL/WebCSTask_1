using System.Net;

namespace MulticastLibrary;

public class ClientInfo
{
    public IPEndPoint EndPoint { get; set; } = null!;

    public Action<CompanyMessage>? OnNews;

    public Action<CompanyMessage>? OnReminder;

    public Action<CompanyMessage>? OnEntertainment;

    public Action<CompanyMessage>? OnEmergency;
}