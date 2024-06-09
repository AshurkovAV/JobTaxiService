using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class User
{
    public int Id { get; set; }

    public string? IdYandex { get; set; }

    public string? Login { get; set; }

    public string? ClientId { get; set; }

    public string? DisplayName { get; set; }

    public string? RealName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Sex { get; set; }

    public string? DefaultEmail { get; set; }

    public DateTime? Birthday { get; set; }

    public string? DefaultAvatarId { get; set; }

    public string? IsAvatarEmpty { get; set; }

    public string? DefaultPhone { get; set; }

    public string? DeviceId { get; set; }
}
