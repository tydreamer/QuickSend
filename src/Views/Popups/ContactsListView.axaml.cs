using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuickSend.Views;

public class ContactsListView : UserControl
{
    public ContactsListView()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}