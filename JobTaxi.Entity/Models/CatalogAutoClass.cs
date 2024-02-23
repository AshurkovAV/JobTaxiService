using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class CatalogAutoClass
{
    public int Id { get; set; }

    public string RTypeChar { get; set; } = null!;

    public string RName { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public string? NameView { get; set; }
}
