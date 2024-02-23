using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class RegistrationCall
{
    public int Id { get; set; }

    public string Fam { get; set; } = null!;

    public string Im { get; set; } = null!;

    public string? Ot { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsAgreed { get; set; }

    public bool? Active { get; set; }

    public string? Ip { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
