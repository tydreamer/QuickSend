using QuickSend.Models;

namespace QuickSend.ViewModels;

internal class MessagePackageViewModel : ViewModelBase
{
    public MessagePackageViewModel(MessagePackage message)
        => this.Message = message;
    
    private MessagePackage Message { get; }
}