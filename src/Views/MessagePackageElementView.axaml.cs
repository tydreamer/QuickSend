using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using QuickSend.Enums;
using QuickSend.Models;
using QuickSend.UtilityCollection;

namespace QuickSend.Views;

public class MessagePackageElementView : UserControl
{
    public MessagePackageElementView()
    {
        InitializeComponent();
        this.Initialized += OnInitialized;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void OnInitialized(object? sender, EventArgs e)
    {
        Grid fixedSizeGrid = this.Get<Grid>("FixedSizeGrid");
        TextBlock nicknameText = this.Get<TextBlock>("SenderNickname");

        const int autoIndex = 0;
        const int fixedIndex = 1;
        ColumnDefinition autoColumn = fixedSizeGrid.ColumnDefinitions[autoIndex];
        ColumnDefinition fixedColumn = fixedSizeGrid.ColumnDefinitions[fixedIndex];

        Action additionalAction = () =>
        {
            if (this.DataContext is MessagePackage package)
            {
                package.TimeChanged += async (o, args) => 
                    await Utilities.UpdateColumns(fixedSizeGrid, nicknameText, autoIndex, fixedIndex, true);
            }
        };
        
        Utilities.LimitAutoSize(fixedSizeGrid, nicknameText, GridOrientation.Column, autoIndex, fixedIndex, additionalAction);
    }
}