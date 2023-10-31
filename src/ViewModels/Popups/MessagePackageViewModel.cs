using QuickSend.Models;

namespace QuickSend.ViewModels;

internal class MessagePackageViewModel : ViewModelBase
{
    public MessagePackageViewModel(MessagePackage message)
        => this.Message = message;
    
    internal MessagePackage Message { get; }
}