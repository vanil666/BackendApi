using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public int ListingId { get; set; }

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Address { get; set; }

    public virtual Listing Listing { get; set; } = null!;
}
