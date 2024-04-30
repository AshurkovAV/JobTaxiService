﻿using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UserToken
{
    public int Id { get; set; }

    public string? TokenType { get; set; }

    public string? AccessToken { get; set; }

    public int? ExpiresIn { get; set; }

    public string? RefreshToken { get; set; }

    public string? Scope { get; set; }

    public string? DeviceId { get; set; }

    public DateTime DateEdit { get; set; }
}
