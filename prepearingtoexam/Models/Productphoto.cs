using System;
using System.Collections.Generic;

namespace prepearingtoexam.Models;

public partial class Productphoto
{
    public int Id { get; set; }

    public int Productid { get; set; }

    public string? Photopath { get; set; }

    public virtual Product Product { get; set; } = null!;
}
