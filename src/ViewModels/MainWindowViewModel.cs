using System.Net;
using QuickSend.Models;

namespace QuickSend.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    internal NetworkServer Server { get; }
    
    public MainWindowViewModel()
    {
        Server = new NetworkServer();
        Server.MessageReceived += OnMessageReceived;
    }

    private void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        // TODO: Do something
    }

    private async void Send()
    {
        IPAddress ip = await UtilityCollection.Utilities.GetIpAddress();
        var client = new NetworkClient(ip);
        await client.SendData();
    }
}