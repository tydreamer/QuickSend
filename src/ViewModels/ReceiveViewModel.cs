using System.Collections.ObjectModel;
using QuickSend.Models;
using QuickSend.Models.NetworkTransmission;
using QuickSend.UtilityCollection;
using ReactiveUI;

namespace QuickSend.ViewModels;

public sealed class ReceiveViewModel : NetworkViewModelBase
{
    internal NetworkServer Server { get; }
    
    private ObservableCollection<MessageReceivedEventArgs> Messages { get; } = new();
    private bool MessagesAvailable => Messages.Count > 0;
    
    public ReceiveViewModel() : base(Utilities.UsersList)
    {
        Server = new NetworkServer();
        Server.MessageReceived += OnMessageReceived;
        Messages.CollectionChanged += (sender, args) => this.RaisePropertyChanged(nameof(MessagesAvailable));
    }
    
    private void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Messages.Add(e);
        Utilities.Log($"\nRECEIVED MESSAGE:");
        Utilities.Log($"From: {e.Sender?.Nickname}");
        Utilities.Log($"Message: {e.TextMessage}\n");
    }
}