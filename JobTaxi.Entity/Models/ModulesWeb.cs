using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class ModulesWeb
{
    public int ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public string ModuleDescription { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<MenuWeb> MenuWebs { get; set; } = new List<MenuWeb>();

    public virtual ICollection<RestrictedEntitiesWeb> RestrictedEntitiesWebs { get; set; } = new List<RestrictedEntitiesWeb>();

    public virtual ICollection<RulesWeb> RulesWebs { get; set; } = new List<RulesWeb>();
}
