using System;
using System.Collections.Generic;

namespace prepearingtoexam.Models;

public partial class Manufacture
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Startday { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
