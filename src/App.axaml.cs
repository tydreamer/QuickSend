using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using QuickSend.Models;
using QuickSend.Services;
using QuickSend.UtilityCollection;
using QuickSend.ViewModels;
using QuickSend.Views;

namespace QuickSend;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (!DataManager.LoadData(Utilities.MetaDataPath, out MetaData? metaData))
            {
                metaData = new MetaData(true, null, new ObservableCollection<User>(), new List<User>());
                DataManager.SaveData(metaData, Utilities.MetaDataPath);
            }

            LoadMetaData(metaData!);
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void LoadMetaData(MetaData metaData)
    {
        ApplicationVariables.MetaData = metaData;
    }
}