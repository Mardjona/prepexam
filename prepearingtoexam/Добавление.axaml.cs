using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using prepearingtoexam.Models;

namespace prepearingtoexam;

public partial class Добавление : Window
{
    private Product product;
    public Добавление()
    {
        InitializeComponent();
       product = new Product();
    }

    public void AddButton(object sender, RoutedEventArgs e)
    {
        Helper.Database.Products.Add(product);
        Helper.Database.SaveChanges();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}