﻿using System;
using System.Collections.Generic;

namespace prepearingtoexam.Models;

public partial class Productsale
{
    public int Id { get; set; }

    public DateOnly? Saledate { get; set; }

    public int Productid { get; set; }

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
