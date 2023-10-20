using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class CategoryMst
{
    public int CategoryId { get; set; }

    public string Categoryname { get; set; } = null!;
}
