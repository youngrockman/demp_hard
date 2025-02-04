using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo_hard.Models;

namespace demo_hard;

public partial class FunctionWindow : Window
{
    public FunctionWindow()
    {
        InitializeComponent();
        DataContext = new Employee();
    }
}