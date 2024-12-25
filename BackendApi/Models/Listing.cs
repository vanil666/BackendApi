using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Listing
{
    public int ListingId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool? IsExchangeable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<ListingCategory> ListingCategories { get; set; } = new List<ListingCategory>();

    public virtual ICollection<ListingImage> ListingImages { get; set; } = new List<ListingImage>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual User User { get; set; } = null!;
}
