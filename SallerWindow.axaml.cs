using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demo_hard.Model;


namespace demo_hard;

public partial class SallerWindow : Window
{
    public SallerWindow()
    {
        InitializeComponent();
        OrderNubmber();
        LoadClients();
        LoadService();
        SearchItems();

    }


    private void OrderNubmber()
    {
        using var context =  new User2Context();
        var OrderId = context.Orders.Max(o => o.Id) + 1;
        if (context.Orders.Any(o => o.Id == OrderId)) throw new ArgumentException("Номера Id не должны совпадать");
        if (OrderId < 1) throw new ArgumentException("OrderId must be greater than 1");
        CompleteBox.ItemsSource = new string[] {OrderId.ToString()};
    }
    private void LoadClients()
    {
        using var context =  new User2Context();
        var client = context.Clients.ToList();
        Clients_ComboBox.ItemsSource = client;
    }

    private void Clients_ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Clients_ComboBox.SelectedItem is Client selectedClient)
        {
            Console.WriteLine($"Вы выбрали: {selectedClient.Fio}");
        }
    }

    private void Go_Back_Button(object? sender, RoutedEventArgs e)
    {
        new FunctionWindow().ShowDialog(this);
    }

    private void LoadService()
    {
        using var context =  new User2Context();
        var service = context.Services.ToList();
        Service_Combobox.ItemsSource = service;
    }

    private void Serice_Combobox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Clients_ComboBox.SelectedItem is Service selectedServiceName)
        {
            Console.WriteLine($"Вы выбрали улугу: {selectedServiceName.ServiceName}");
        }
    }

    private void SearchItems()
    {
        using var context =  new User2Context();
        string seacrhText = SearchBox.Text?.ToLower() ?? "";
        if (string.IsNullOrWhiteSpace(seacrhText))
        {
            SearchResultsListBox.ItemsSource = new List<string>();
        }

        var clientRes = context.Clients.ToList().Where(c => c.Fio.ToLower().Contains(seacrhText))
            .Select(c=> $"{c.Fio}");
        var SeviceRes = context.Services.ToList().Where(s => s.ServiceName.ToLower().Contains(seacrhText))
            .Select(s => $"{s.ServiceName}");
        
        var results = clientRes.Concat(SeviceRes).ToList();
        SearchResultsListBox.ItemsSource = results;
        
    }


    private void SeacrchBox_Changed(object? sender, TextChangedEventArgs e)
    {
        SearchItems();
    }

    private void AddUser_Button(object? sender, RoutedEventArgs e)
    {
         new AddClient().ShowDialog(this);
    }
}