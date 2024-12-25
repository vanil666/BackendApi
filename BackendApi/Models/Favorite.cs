using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int UserId { get; set; }

    public int ListingId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Listing Listing { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
