using System.Collections.ObjectModel;
using QuickSend.Models;

namespace QuickSend.ViewModels;

public abstract class NetworkViewModelBase : ViewModelBase
{
    protected ObservableCollection<User>? UsersList { get; }

    protected NetworkViewModelBase(ObservableCollection<User>? usersList) 
        => UsersList = usersList;
}