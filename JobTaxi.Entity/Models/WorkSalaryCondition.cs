using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class WorkSalaryCondition
{
    public int Id { get; set; }

    public int ParkId { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
