using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class Park
{
    public int Id { get; set; }

    public string ParkGuid { get; set; } = null!;

    public string ParkName { get; set; } = null!;

    public string ParkAddress { get; set; } = null!;

    public string? AddressLatitude { get; set; }

    public string? AddressLongitude { get; set; }

    public string? YandexTaxoparkId { get; set; }

    public double ParkPercent { get; set; }

    public bool SelfEmployed { get; set; }

    public string? SelfEmployedSum { get; set; }

    public int WithdrawMoneyId { get; set; }

    public double WithdrawMoney { get; set; }

    public string Penalties { get; set; } = null!;

    public string Deposit { get; set; } = null!;

    public string DepositRet { get; set; } = null!;

    public string Waybills { get; set; } = null!;

    public string Inspection { get; set; } = null!;

    public bool Insurance { get; set; }

    public string MinRentalPeriod { get; set; } = null!;

    public string WorkRadius { get; set; } = null!;

    public string RentalWriteOffTime { get; set; } = null!;

    public bool GasThrowTaxometr { get; set; }

    public int FirstDayId { get; set; }

    public bool Ransom { get; set; }

    public bool Active { get; set; }

    public string Ip4 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public int? CreatedUserId { get; set; }

    public virtual UsersWeb? CreatedUser { get; set; }

    public virtual FirstDay FirstDay { get; set; } = null!;

    public virtual WithdrayMoneyWay WithdrawMoneyNavigation { get; set; } = null!;
}
