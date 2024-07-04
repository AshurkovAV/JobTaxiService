using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersFilter
{
    public int Id { get; set; }

    public string FilterName { get; set; } = null!;

    public string? AddressLatitude { get; set; }

    public string? AddressLongitude { get; set; }

    public double ParkPercent { get; set; }

    public bool SelfEmployed { get; set; }

    public string? SelfEmployedSum { get; set; }

    public int WithdrawMoneyId { get; set; }

    public double WithdrawMoney { get; set; }

    public string Penalties { get; set; } = null!;

    public string Deposit { get; set; } = null!;

    public bool Insurance { get; set; }

    public string RentalWriteOffTime { get; set; } = null!;

    public bool GasThrowTaxometr { get; set; }

    public int FirstDayId { get; set; }

    public bool Ransom { get; set; }

    public int DepositRetId { get; set; }

    public int WaybillsId { get; set; }

    public int WorkRadiusId { get; set; }

    public int InspectionId { get; set; }

    public int MinRentalPeriodId { get; set; }

    public bool Active { get; set; }

    public string Ip4 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}
