using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Car
{
    public int Id { get; set; }

    public string CarName { get; set; } = null!;

    public string? Model { get; set; }

    public string? Color { get; set; }

    public string? Number { get; set; }

    public int Year { get; set; }

    public string? CarYandexTaxoparkId { get; set; }

    public int? SchemId { get; set; }

    public double PriceForDay { get; set; }

    public int CatalogAutoClassId { get; set; }

    public bool IsCarsGiven { get; set; }

    public bool IsLoadedFromYandex { get; set; }

    public int? ParkId { get; set; }

    public bool? Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual ICollection<CarsPicture> CarsPictures { get; set; } = new List<CarsPicture>();

    public virtual CatalogAutoClass CatalogAutoClass { get; set; } = null!;

    public virtual Park? Park { get; set; }

    public virtual Schem? Schem { get; set; }
}
