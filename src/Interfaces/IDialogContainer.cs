using QuickSend.ViewModels;

namespace QuickSend.Interfaces;

public interface IDialogContainer
{
    public DialogViewModelBase? CurrentDialog { get; set; }
}