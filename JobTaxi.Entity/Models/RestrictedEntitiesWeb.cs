using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RestrictedEntitiesWeb
{
    public int EntityId { get; set; }

    public string EntityName { get; set; } = null!;

    public int ModuleId { get; set; }

    public string EntityDescription { get; set; } = null!;

    public virtual ModulesWeb Module { get; set; } = null!;

    public virtual ICollection<RulesWeb> RulesWebs { get; set; } = new List<RulesWeb>();
}
