using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class ListingCategory
{
    public int ListingCategoryId { get; set; }

    public int ListingId { get; set; }

    public int CategoryId { get; set; }

    public virtual CarCategory Category { get; set; } = null!;

    public virtual Listing Listing { get; set; } = null!;
}
