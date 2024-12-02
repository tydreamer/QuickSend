using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuickSend.Views;

public class ProfilePageView : UserControl
{
    public ProfilePageView()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}