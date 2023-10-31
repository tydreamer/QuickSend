using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuickSend.Interfaces;

public interface INotifyPropertyChangedHelper : INotifyPropertyChanged
{
    void NotifyPropertyChanged([CallerMemberName] string propertyName = "");
}