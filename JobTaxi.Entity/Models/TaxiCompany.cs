using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class TaxiCompany
{
    public int Id { get; set; }

    public string TxName { get; set; } = null!;

    public string? TxAdress { get; set; }

    public string? TxDriver { get; set; }

    public bool? Active { get; set; }

    public int Ip4 { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
