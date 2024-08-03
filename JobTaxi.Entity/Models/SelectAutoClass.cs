using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class SelectAutoClass
{
    public int Id { get; set; }

    public int AutoClassId { get; set; }

    public int UserId { get; set; }

    public bool? Active { get; set; }

    public string Ip4 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
