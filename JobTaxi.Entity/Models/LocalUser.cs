using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class LocalUser
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Pass { get; set; }

    public string? Salt { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public byte[]? Image { get; set; }

    public string? ConfNumber { get; set; }

    public int? RoleId { get; set; }

    public bool? Active { get; set; }

    public int Ip4 { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
