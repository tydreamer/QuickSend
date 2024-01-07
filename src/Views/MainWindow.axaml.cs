using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using QuickSend.UtilityCollection;

namespace QuickSend.Views;

public class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        Instance = this;
        this.Closing += (sender, args) => Utilities.DeleteDirectory(Utilities.TemporaryFilesPath);
    }
    
    ~MainWindow() => Utilities.DeleteDirectory(Utilities.TemporaryFilesPath);

    internal static MainWindow? Instance { get; private set; }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}