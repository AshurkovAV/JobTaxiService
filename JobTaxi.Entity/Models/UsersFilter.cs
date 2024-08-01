using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersFilter
{
    public int Id { get; set; }

    public string FilterName { get; set; } = null!;

    public string? AddressLatitude { get; set; }

    public string? AddressLongitude { get; set; }

    public double? ParkPercent { get; set; }

    public int FilterUserId { get; set; }

    public bool? Active { get; set; }

    public string Ip4 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
