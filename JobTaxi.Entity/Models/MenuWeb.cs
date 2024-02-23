using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class MenuWeb
{
    public int MenuId { get; set; }

    public string MenuTitle { get; set; } = null!;

    public int? ChiefId { get; set; }

    public int ModuleId { get; set; }

    public string Link { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual MenuWeb? Chief { get; set; }

    public virtual ICollection<MenuWeb> InverseChief { get; set; } = new List<MenuWeb>();

    public virtual ModulesWeb Module { get; set; } = null!;
}
