using Avalonia.Controls;
using Avalonia.Interactivity;

namespace demo_hard;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TogglePasswordVisibility(object? sender, RoutedEventArgs e)
    {
        PasswordBox.PasswordChar = PasswordBox.PasswordChar == '*' ? '\0' : '*';
    }

    private void AuthorizeButton(object? sender, RoutedEventArgs e)
    {
        new FunctionWindow().ShowDialog(this);
    }
}