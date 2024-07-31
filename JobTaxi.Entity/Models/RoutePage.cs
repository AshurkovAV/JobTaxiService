using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RoutePage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }
}
