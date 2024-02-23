using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RolesWeb
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RightsWeb> RightsWebs { get; set; } = new List<RightsWeb>();

    public virtual ICollection<UsersErrorsLog> UsersErrorsLogs { get; set; } = new List<UsersErrorsLog>();

    public virtual ICollection<UsersWeb> UsersWebs { get; set; } = new List<UsersWeb>();
}
