using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class LoginFailedAttempt
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public DateTime NoteDatetime { get; set; }

    public string? IpAddress { get; set; }

    public bool HasLoginInRegUsers { get; set; }
}
