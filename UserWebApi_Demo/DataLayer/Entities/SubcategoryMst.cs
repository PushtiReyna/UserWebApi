using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public partial class SubcategoryMst
{
    public int SubcategoryId { get; set; }

    public int? CategoryId { get; set; }

    public string Subcategoryname { get; set; } = null!;

    [NotMapped]
    public string Categoryname { get; set; }
}
