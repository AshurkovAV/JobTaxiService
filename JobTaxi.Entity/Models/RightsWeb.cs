using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RightsWeb
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int RuleId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual RolesWeb Role { get; set; } = null!;

    public virtual RulesWeb Rule { get; set; } = null!;
}
