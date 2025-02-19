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
    private List<Service> SelectedServices = new();

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
        using var context = new User2Context();
        var OrderId = context.Orders.Max(o => o.Id) + 1;
        if (context.Orders.Any(o => o.Id == OrderId)) throw new ArgumentException("Номера Id не должны совпадать");
        if (OrderId < 1) throw new ArgumentException("OrderId must be greater than 1");
        CompleteBox.ItemsSource = new string[] { OrderId.ToString() };
    }

    private void LoadClients()
    {
        using var context = new User2Context();
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
        using var context = new User2Context();
        var service = context.Services.ToList();
        Service_Combobox.ItemsSource = service;
    }

    private void Service_Combobox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Service_Combobox.SelectedItem is Service selectedService)
        {
            Console.WriteLine($"Вы выбрали услугу: {selectedService.ServiceName}");
        }
    }

    private void AddService_Button(object? sender, RoutedEventArgs e)
    {
        if (Service_Combobox.SelectedItem is Service selectedService && !SelectedServices.Contains(selectedService))
        {
            SelectedServices.Add(selectedService);
            UpdateServiceList();
        }
    }

    private void UpdateServiceList()
    {
        SelectedServicesListBox.ItemsSource = null;
        SelectedServicesListBox.ItemsSource = SelectedServices.Select(s => s.ServiceName).ToList();
    }

    private void SearchItems()
    {
        using var context = new User2Context();
        string searchText = SearchBox.Text?.ToLower() ?? "";
        if (string.IsNullOrWhiteSpace(searchText))
        {
            SearchResultsListBox.ItemsSource = new List<string>();
            return;
        }

        var clientRes = context.Clients
            .Where(c => c.Fio.ToLower().Contains(searchText))
            .Select(c => c.Fio);

        var serviceRes = context.Services
            .Where(s => s.ServiceName.ToLower().Contains(searchText))
            .Select(s => s.ServiceName);

        var results = clientRes.Concat(serviceRes).ToList();
        SearchResultsListBox.ItemsSource = results;
    }

    private void SearchBox_Changed(object? sender, TextChangedEventArgs e)
    {
        SearchItems();
    }

    private void AddUser_Button(object? sender, RoutedEventArgs e)
    {
        new AddClient().ShowDialog(this);
    }
}
