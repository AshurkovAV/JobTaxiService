using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersErrorsLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string? PageUrl { get; set; }

    public string ErrorInfo { get; set; } = null!;

    public string? FilterData { get; set; }

    public DateTime DateAdded { get; set; }

    public virtual RolesWeb Role { get; set; } = null!;

    public virtual UsersWeb User { get; set; } = null!;
}
