using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class CarsPicture
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public byte[] Picture { get; set; } = null!;

    public virtual Car Car { get; set; } = null!;
}
