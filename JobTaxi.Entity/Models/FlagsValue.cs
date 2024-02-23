using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class FlagsValue
{
    public int Code { get; set; }

    public string Val { get; set; } = null!;
}
