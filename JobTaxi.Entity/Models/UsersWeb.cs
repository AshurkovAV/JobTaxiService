using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersWeb
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fam { get; set; } = null!;

    public string Im { get; set; } = null!;

    public string? Ot { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? LastVisit { get; set; }

    public int? RoleIdVisit { get; set; }

    public DateTime? CreationDate { get; set; }

    public int IsActive { get; set; }

    public string? AuthId { get; set; }

    public virtual ICollection<Park> Parks { get; set; } = new List<Park>();

    public virtual RolesWeb? RoleIdVisitNavigation { get; set; }

    public virtual ICollection<UsersErrorsLog> UsersErrorsLogs { get; set; } = new List<UsersErrorsLog>();

    public virtual ICollection<UsersLog> UsersLogs { get; set; } = new List<UsersLog>();
}
