using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Offer
{
    public int Id { get; set; }

    public int ParkId { get; set; }

    public int DriverId { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public int? StatusId { get; set; }

    public string? Comments { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Park Park { get; set; } = null!;

    public virtual OffersStatus? Status { get; set; }
}
