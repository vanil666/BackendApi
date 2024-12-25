using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class ListingImage
{
    public int ImageId { get; set; }

    public int ListingId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Listing Listing { get; set; } = null!;
}
