using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Inspection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual ICollection<Park> Parks { get; set; } = new List<Park>();
}
