using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using demo_hard.Model;

namespace demo_hard;

public partial class FunctionWindow : Window
{
    public FunctionWindow(Employee user)
    {
        InitializeComponent();
        DataContext = new ImageEmployee()
        {
            EmployeId = user.EmployeId,
            Fio = user.Fio,
            EmployeLogin = user.EmployeLogin,
            EmployePassword = user.EmployePassword,
            RoleId = user.RoleId,
            EmployePhoto = user.EmployePhoto
        };
    }
    
    
    
    public FunctionWindow()
    {
        InitializeComponent();
    }


    private void Back_Button(object? sender, RoutedEventArgs e)
    {
        new MainWindow().ShowDialog(this);
    }

    private void Next_Function_Button(object? sender, RoutedEventArgs e)
    {
        new SallerWindow().ShowDialog(this);    
    }

    
    public class ImageEmployee: Employee
    {
        Bitmap? Image
        {
            get
            {
                try
                {
                    string absolutePath = Path.Combine(AppContext.BaseDirectory, EmployePhoto);
                    return new Bitmap(absolutePath);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    }
}