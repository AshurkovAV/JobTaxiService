using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Update
{
    public int Id { get; set; }

    public string Src { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Dst { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string BaseVersion { get; set; } = null!;

    public string ResultVersion { get; set; } = null!;

    public string ResultStatus { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
