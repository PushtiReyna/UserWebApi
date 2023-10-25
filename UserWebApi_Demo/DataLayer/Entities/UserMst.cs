using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserMst
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Mobilenumber { get; set; } = null!;

    public decimal Percentage { get; set; }

    public DateTime Dob { get; set; }

    public int CategoryId { get; set; }

    public int SubcategoryId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public bool CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool UpdateBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
