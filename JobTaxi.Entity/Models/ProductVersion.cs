using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class ProductVersion
{
    public string EntityCode { get; set; } = null!;

    public string CurrentVersion { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
