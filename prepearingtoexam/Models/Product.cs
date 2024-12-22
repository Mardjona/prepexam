using System;
using System.Collections.Generic;
using System.Drawing;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace prepearingtoexam.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public double? Cost { get; set; }

    public bool? Isactive { get; set; }

    public string? Mainphotopath { get; set; }

    public int Manufactureid { get; set; }

    public string? Description { get; set; }

    public virtual Manufacture Manufacture { get; set; } = null!;

    public virtual ICollection<Productphoto> Productphotos { get; set; } = new List<Productphoto>();

    public virtual ICollection<Productsale> Productsales { get; set; } = new List<Productsale>();

    public virtual ICollection<Product> Attacehedproducts { get; set; } = new List<Product>();

    public virtual ICollection<Product> Mainproducts { get; set; } = new List<Product>();
    public Bitmap? Image  => Mainphotopath != null ? new Bitmap($"./schoolproducts/{Mainphotopath}") : null;
    public string GetCOst => Cost + " рублей";
}
