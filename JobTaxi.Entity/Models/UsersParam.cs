using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersParam
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string? Phone { get; set; }

    public string? Park { get; set; }
}
