using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using demo_hard.Model;
using Tmds.DBus.Protocol;

namespace demo_hard;

public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();
        LoadInfo();
    }

    private void LoadInfo()
    {
        using var context = new User2Context();
        LastEnterBox.ItemsSource = context.LastEnters.ToList();
    }
 }