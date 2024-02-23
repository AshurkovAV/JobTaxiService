using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RulesWeb
{
    public int RuleId { get; set; }

    public string RuleName { get; set; } = null!;

    public int ModuleId { get; set; }

    public int? EntityId { get; set; }

    public int? RestrictTypeId { get; set; }

    public string? RestrictDefaultValue { get; set; }

    public bool IsAdmin { get; set; }

    public virtual RestrictedEntitiesWeb? Entity { get; set; }

    public virtual ModulesWeb Module { get; set; } = null!;

    public virtual ControlsRestrictionType? RestrictType { get; set; }

    public virtual ICollection<RightsWeb> RightsWebs { get; set; } = new List<RightsWeb>();
}
