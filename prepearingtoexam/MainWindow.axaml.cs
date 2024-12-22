using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using prepearingtoexam.Models;

namespace prepearingtoexam;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loadproduct();
    }

    private void Loadproduct()
    {
        List<Product> products = Helper.Database.Products.ToList();
        if (Search_Textbox == null || filter_combobox == null || choose_comboBox ==null) return;
        if(!string.IsNullOrWhiteSpace(Search_Textbox.Text))
        {
            products = products.Where(x => x.Title.ToLower().Contains(Search_Textbox.Text.ToLower())).ToList();
        }
        else
        {
            products = products.ToList();
        }
        switch (filter_combobox.SelectedIndex)
        {
            case 0:
                products = products.ToList();  
                break;
            case 1:
                products = products.OrderBy(x =>x.Cost).ToList();
                break;
            case 2: 
                products = products.OrderByDescending(x => x.Cost).ToList(); 
                break;
            default: 
                products = products.ToList(); break;
            

        }

        switch (choose_comboBox.SelectedIndex)
        {
            case 0:
                products = products.ToList();  
                break;
            case 1:
                products = products.Where(x => x.Manufactureid == 1).ToList();
                break;
            case 2: 
                products = products.Where(x => x.Manufactureid == 2).ToList();
                break;
            case 3:
                products = products.Where(x => x.Manufactureid == 3).ToList();
                break;
            default: products = products.ToList();  break;
        }
        
        Product_Listbox.ItemsSource = products.ToList();

    }
     public void EditBut(object? sender,PointerReleasedEventArgs args)
     {
         var product = Product_Listbox.SelectedItem as Product; 
         Редактирование редактирование = new Редактирование(product);
         редактирование.Show();
        Close();

     }

     public void AddButton(object? sender, Avalonia.Interactivity.RoutedEventArgs args)
     {
         Добавление добавление = new Добавление();
         добавление.Show();
         Close();
     }

  

    private void Search_TextChanged(object sender, TextChangedEventArgs e) => Loadproduct();
    private void filter_changed(object? sender,  SelectionChangedEventArgs args) => Loadproduct();
    private void choose_changed (object? sender,  SelectionChangedEventArgs args) => Loadproduct();

   
}