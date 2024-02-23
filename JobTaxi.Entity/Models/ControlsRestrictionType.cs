using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class ControlsRestrictionType
{
    public int RestrictionId { get; set; }

    public string RestrictionName { get; set; } = null!;

    public string RestrictionTitle { get; set; } = null!;

    public virtual ICollection<RulesWeb> RulesWebs { get; set; } = new List<RulesWeb>();
}
