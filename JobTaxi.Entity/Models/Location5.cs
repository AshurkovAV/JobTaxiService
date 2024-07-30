using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Location5
{
    public int Id { get; set; }

    public int? OblId { get; set; }

    public string? OblName { get; set; }

    public int? GorId { get; set; }

    public string? GorName { get; set; }

    public string? Obls { get; set; }
}
