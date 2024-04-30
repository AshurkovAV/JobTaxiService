using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class ParksWorkCondition
{
    public int Id { get; set; }

    public string ParkGuid { get; set; } = null!;

    public int WorkConditionId { get; set; }

    public virtual Park Park { get; set; } = null!;

    public virtual WorkCondition WorkCondition { get; set; } = null!;
}
