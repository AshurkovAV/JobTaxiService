using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class CarsPicture
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public byte[] Picture { get; set; } = null!;

    public byte[]? ThumbPicture { get; set; }

    public virtual Car Car { get; set; } = null!;
}
