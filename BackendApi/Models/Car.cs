using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Car
{
    public int CarId { get; set; }

    public int ListingId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public int Mileage { get; set; }

    public string Condition { get; set; } = null!;

    public string Transmission { get; set; } = null!;

    public string FuelType { get; set; } = null!;

    public virtual Listing Listing { get; set; } = null!;
}
