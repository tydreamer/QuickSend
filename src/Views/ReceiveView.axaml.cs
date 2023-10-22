using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuickSend.Views;

public class ReceiveView : UserControl
{
    public ReceiveView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}