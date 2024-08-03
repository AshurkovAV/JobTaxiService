using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Dto.User;

public partial class UsersFilterDto
{
    public int Id { get; set; }

    public string FilterName { get; set; } = null!;

    public string? AddressLatitude { get; set; }

    public string? AddressLongitude { get; set; }

    public double? ParkPercent { get; set; }
    public int FilterUserId { get; set; }
    public bool IsPush { get; set; }

}
