using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class ParksDriversConstraint
{
    public int Id { get; set; }

    public string ParkGuid { get; set; } = null!;

    public int DriversConstraintId { get; set; }

    public virtual DriversConstraint DriversConstraint { get; set; } = null!;

    public virtual Park Park { get; set; } = null!;
}
