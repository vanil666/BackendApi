using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class CarCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<CarCategory> InverseParentCategory { get; set; } = new List<CarCategory>();

    public virtual ICollection<ListingCategory> ListingCategories { get; set; } = new List<ListingCategory>();

    public virtual CarCategory? ParentCategory { get; set; }
}
