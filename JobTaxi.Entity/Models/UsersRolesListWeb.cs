using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersRolesListWeb
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual RolesWeb Role { get; set; } = null!;

    public virtual UsersWeb User { get; set; } = null!;
}
