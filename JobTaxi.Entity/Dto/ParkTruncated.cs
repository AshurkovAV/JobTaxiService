using JobTaxi.Entity.Models;

namespace JobTaxi.Entity.Dto
{
    public class ParkTruncated
    {
        public int Id { get; set; }
        public string ParkGuid { get; set; }
        public string ParkName { get; set; } = null!;
        public string ParkAddress { get; set; } = null!; 
        public string? AddressLatitude { get; set; }
        public string? AddressLongitude { get; set; }
        public double ParkPercent { get; set; }
        public bool SelfEmployed { get; set; } //Самозанятый
        public string? SelfEmployedSum { get; set; }//Сумма доп. взноса для самозанятых
        public string? WithdrawMoneyName { get; set; }//Расчет суммы за вывод денег *
        public double WithdrawMoney { get; set; }//Вывод денег: значение *
        public string? Penalties { get; set; } //Штрафы

        public string Deposit { get; set; } //Депозит *
        public string DepositRet { get; set; } //Возврат депозита *
        public string Waybills { get; set; } //Путевые *
        public string Inspection { get; set; } //Осмотр *
        public bool Insurance { get; set; } //Страховка *
        public string MinRentalPeriod { get; set; } //Мин. срок аренды *
        public string WorkRadius { get; set; } //Радиус работы * *
        public string rentalWriteOffTime { get; set; } //Время списания аренды * *
        public bool GasThrowTaxometr { get; set; } //Заправка через таксометр * *
        public string? FirstDayName { get; set; }//Первый день *
        public bool Ransom { get; set; }//Выкуп
        public List<Car> Cars { get; set; }


        public DateTime CreatedAt { get; set; }
       
        public string ParkPhone { get; set; } = null!;
         public byte[] CarAvatar { get; set; }
        public int CountCars { get; set; }
        public int CountDrive { get; set; }
        public int CountWork { get; set; }


    }
}
