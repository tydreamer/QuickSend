using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuickSend.Views;

public class MessagePackageElementView : UserControl
{
    public MessagePackageElementView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}