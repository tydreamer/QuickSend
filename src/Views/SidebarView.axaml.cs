using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuickSend.Views;

public class SidebarView : UserControl
{
    public SidebarView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}