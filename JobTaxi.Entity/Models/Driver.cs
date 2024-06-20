using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string Fam { get; set; } = null!;

    public string Im { get; set; } = null!;

    public string? Ot { get; set; }

    public DateTime? Dr { get; set; }

    public string Phone { get; set; } = null!;

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
