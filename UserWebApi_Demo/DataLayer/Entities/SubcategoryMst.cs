using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class SubcategoryMst
{
    public int SubcategoryId { get; set; }

    public int? CategoryId { get; set; }

    public string Subcategoryname { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public bool CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool UpdateBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
