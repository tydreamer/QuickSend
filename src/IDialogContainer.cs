using QuickSend.ViewModels;

namespace QuickSend;

public interface IDialogContainer
{
    public DialogViewModelBase? CurrentDialog { get; set; }
}