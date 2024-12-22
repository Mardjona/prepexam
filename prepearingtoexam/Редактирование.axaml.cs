using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using prepearingtoexam.Models;
namespace prepearingtoexam;

public partial class Редактирование : Window
{
    private Product currentProduct;
    public Редактирование()
    {
        InitializeComponent();
    }
    public Редактирование(Product product)
    {
        InitializeComponent();
        currentProduct = product;
        
        ProductModel.DataContext = currentProduct;
    }

    public void Savebutton(object sender, RoutedEventArgs e)
    {
        
        Helper.Database.Products.Update(currentProduct);
        Helper.Database.SaveChanges();
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();

    }

    public void Canselbutton(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private async void OnOpenFolderButtonClick(object sender, RoutedEventArgs e)
    {
       /* var dialog = new OpenFileDialog();
        var result = await dialog.ShowAsync(this);
        if (result != null )
        {
            var selectedFilePath = result[0]; // Загружаем изображение в элемент Image
            var bitmap = new Bitmap(selectedFilePath);
            SelectedImage.Source = bitmap;
            currentProduct.Mainphotopath = selectedFilePath;
            }*/
           
           
            
        

    }
}
    
       
    
        
    


