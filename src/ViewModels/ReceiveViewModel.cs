using System.Collections.ObjectModel;
using QuickSend.Events;
using QuickSend.Models;
using QuickSend.Models.NetworkTransmission;
using QuickSend.UtilityCollection;
using ReactiveUI;

namespace QuickSend.ViewModels;

public sealed class ReceiveViewModel : NetworkViewModelBase
{
    internal NetworkServer Server { get; }
    
    private ObservableCollection<MessagePackage> Messages { get; } = new();
    private bool MessagesAvailable => Messages.Count > 0;
    
    public ReceiveViewModel() : base(Utilities.UsersList)
    {
        Server = new NetworkServer();
        Server.MessageReceived += OnMessageReceived;
        Messages.CollectionChanged += (sender, args) => this.RaisePropertyChanged(nameof(MessagesAvailable));
    }
    
    private void OnMessageReceived(object? sender, MessageReceivedEventArgs args)
    {
        var message = new MessagePackage(args);
        Messages.Insert(0, message);
        Utilities.Log($"\nRECEIVED MESSAGE:");
        Utilities.Log($"From: {message.Sender?.Nickname}");
        Utilities.Log($"Message: {message.TextMessage}\n");
    }
    
    private void OpenMessage(MessagePackage message)
    {
        message.IsRead = true;
        // Create a new ViewModel for the View that should be displayed with data filled in
    }
}