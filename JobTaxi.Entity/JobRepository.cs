using Azure;
using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.Nsi;
using JobTaxi.Entity.Dto.Park;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Transactions;

namespace JobTaxi.Entity
{
    public class JobRepository : IJobRepository
    {
        private readonly ILogger _logger;

        public JobRepository(ILoggerFactory loggerFactory) 
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "/logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        public IEnumerable<CatalogAutoClass> GetCatalogAutoClasses()
        {
            var result = new List<CatalogAutoClass>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.CatalogAutoClasses.ToList();
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            
            return result;
        }

        public IEnumerable<Park> GetParks()
        {
            var result = new List<Park>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Parks.ToList();
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page)
        {
            var result = new List<ParkTruncated>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Parks
                        .OrderBy(b => b.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .Select(x => new ParkTruncated
                        {
                            Id = x.Id,
                            ParkGuid = x.ParkGuid,
                            ParkName = x.ParkName,
                            ParkAddress = x.ParkAddress,
                            AddressLatitude = x.AddressLatitude,
                            AddressLongitude = x.AddressLongitude,
                            ParkPhone = x.ParkPhone,
                            ParkPercent = x.ParkPercent,
                            SelfEmployed = x.SelfEmployed,
                            SelfEmployedSum = x.SelfEmployedSum,
                            WithdrawMoneyName = (from mon in db.WithdrayMoneyWays
                                                 where mon.Id == x.WithdrawMoneyId
                                                 select mon.Name).FirstOrDefault(),
                            WithdrawMoney = x.WithdrawMoney,
                            Penalties = x.Penalties,
                            Deposit = x.Deposit,
                            DepositRet = (from mon in db.DepositRets
                                          where mon.Id == x.DepositRetId
                                          select mon.Name).FirstOrDefault(),
                            Waybills = (from mon in db.Waybills
                                        where mon.Id == x.WaybillsId
                                        select mon.Name).FirstOrDefault(),
                            Inspection = (from mon in db.Inspections
                                          where mon.Id == x.InspectionId
                                          select mon.Name).FirstOrDefault(),
                            Insurance = x.Insurance,
                            MinRentalPeriod = x.MinRentalPeriod,
                            WorkRadius = (from mon in db.WorkRadii
                                          where mon.Id == x.WorkRadiusId
                                          select mon.Name).FirstOrDefault(),  
                            rentalWriteOffTime = x.RentalWriteOffTime,
                            GasThrowTaxometr = x.GasThrowTaxometr,
                            FirstDayName = (from day in db.FirstDays
                                            where day.Id == x.FirstDayId
                                            select day.Name).FirstOrDefault(),
                            Ransom = x.Ransom,
                            CreatedAt = x.CreatedAt,
                            CountCars = (from car in db.Cars
                                         where car.ParkId == x.Id 
                                         && car.Active == true
                                         && car.IsCarsGiven == false
                                         select car ).Count(), 
                            CountDrive = (from count in db.ParksDriversConstraints
                                          where count.ParkGuid == x.ParkGuid
                                          select count).Count(),
                            CountWork = (from count in db.ParksWorkConditions
                                         where count.ParkGuid == x.ParkGuid
                                         select count).Count(),

                        }).ToList();
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<ParkTruncated> GetParksTruncatedToUserId(int rows, int page, int userId)
        {
            var result = new List<ParkTruncated>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Parks
                        .OrderBy(b => b.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .Select(x => new ParkTruncated
                        {
                            Id = x.Id,
                            ParkGuid = x.ParkGuid,
                            ParkName = x.ParkName,
                            ParkAddress = x.ParkAddress,
                            AddressLatitude = x.AddressLatitude,
                            AddressLongitude = x.AddressLongitude,
                            ParkPhone = x.ParkPhone,
                            ParkPercent = x.ParkPercent,
                            SelfEmployed = x.SelfEmployed,
                            SelfEmployedSum = x.SelfEmployedSum,
                            WithdrawMoneyName = (from mon in db.WithdrayMoneyWays
                                                 where mon.Id == x.WithdrawMoneyId
                                                 select mon.Name).FirstOrDefault(),
                            WithdrawMoney = x.WithdrawMoney,
                            Penalties = x.Penalties,
                            Deposit = x.Deposit,
                            DepositRet = (from mon in db.DepositRets
                                          where mon.Id == x.DepositRetId
                                          select mon.Name).FirstOrDefault(),
                            Waybills = (from mon in db.Waybills
                                        where mon.Id == x.WaybillsId
                                        select mon.Name).FirstOrDefault(),
                            Inspection = (from mon in db.Inspections
                                          where mon.Id == x.InspectionId
                                          select mon.Name).FirstOrDefault(),
                            Insurance = x.Insurance,
                            MinRentalPeriod = x.MinRentalPeriod,
                            WorkRadius = (from mon in db.WorkRadii
                                          where mon.Id == x.WorkRadiusId
                                          select mon.Name).FirstOrDefault(),
                            rentalWriteOffTime = x.RentalWriteOffTime,
                            GasThrowTaxometr = x.GasThrowTaxometr,
                            FirstDayName = (from day in db.FirstDays
                                            where day.Id == x.FirstDayId
                                            select day.Name).FirstOrDefault(),
                            Ransom = x.Ransom,
                            CreatedAt = x.CreatedAt,
                            CountCars = (from car in db.Cars
                                         where car.ParkId == x.Id
                                         && car.Active == true
                                         && car.IsCarsGiven == false
                                         select car).Count(),
                            CountDrive = (from count in db.ParksDriversConstraints
                                          where count.ParkGuid == x.ParkGuid
                                          select count).Count(),
                            CountWork = (from count in db.ParksWorkConditions
                                         where count.ParkGuid == x.ParkGuid
                                         select count).Count(),
                            SelectPark = (from count in db.SelectParks
                                          where count.ParkId == x.Id 
                                          && count.Active == true
                                          && count.UserId == userId
                                          select count).Count()

                        }).ToList();
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page, int userId)
        {
            var result = new List<ParkTruncated>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var selectpark = db.SelectParks.Where(x => x.Active == true && x.UserId == userId)
                        .OrderBy(x => x.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                    ;
                    var parks = db.Parks.Where(x => x.Active == true)
                        .Select(x => new ParkTruncated
                        {
                            Id = x.Id,
                            ParkGuid = x.ParkGuid,
                            ParkName = x.ParkName,
                            ParkAddress = x.ParkAddress,
                            AddressLatitude = x.AddressLatitude,
                            AddressLongitude = x.AddressLongitude,
                            ParkPhone = x.ParkPhone,
                            ParkPercent = x.ParkPercent,
                            SelfEmployed = x.SelfEmployed,
                            SelfEmployedSum = x.SelfEmployedSum,
                            WithdrawMoneyName = (from mon in db.WithdrayMoneyWays
                                                 where mon.Id == x.WithdrawMoneyId
                                                 select mon.Name).FirstOrDefault(),
                            WithdrawMoney = x.WithdrawMoney,
                            Penalties = x.Penalties,
                            Deposit = x.Deposit,
                            DepositRet = x.DepositRet,
                            Waybills = x.Waybills,
                            Inspection = x.Inspection,
                            Insurance = x.Insurance,
                            MinRentalPeriod = x.MinRentalPeriod,
                            WorkRadius = x.WorkRadius,
                            rentalWriteOffTime = x.RentalWriteOffTime,
                            GasThrowTaxometr = x.GasThrowTaxometr,
                            FirstDayName = (from day in db.FirstDays
                                            where day.Id == x.FirstDayId
                                            select day.Name).FirstOrDefault(),
                            Ransom = x.Ransom,
                            CreatedAt = x.CreatedAt,
                            CountCars = (from car in db.Cars
                                         where car.ParkId == x.Id
                                         && car.Active == true
                                         && car.IsCarsGiven == false
                                         select car).Count(),
                            CountDrive = (from count in db.ParksDriversConstraints
                                          where count.ParkGuid == x.ParkGuid
                                          select count).Count(),
                            CountWork = (from count in db.ParksWorkConditions
                                         where count.ParkGuid == x.ParkGuid
                                         select count).Count(),
                            SelectPark = 1

                        }).Join(selectpark,
                        park => park.Id, selectpark => selectpark.ParkId, (park, selectpark) => park);
                        

                    result = parks.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<Locatioin1> GetLocation1(int rows, int page)
        {
            var result = new List<Locatioin1>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var data = db.Locatioin1s
                        .OrderBy(b => b.CatId)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .ToList();
                    result = data;
                }
            }
            catch (Exception ex)
            { _logger.LogInformation("Processing {0}", ex.Message); }
            return result;
        }

        public IEnumerable<Location5> GetLocationGorod(int rows, int page)
        {
            var result = new List<Location5>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var data = db.Location5s
                        .OrderBy(b => b.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .ToList();
                    result = data;
                }
            }
            catch (Exception ex)
            { _logger.LogInformation("Processing {0}", ex.Message); }
            return result;
        }

        public IEnumerable<int> GetParksIdAll()
        {
            var result = new List<int>();
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Parks.Select(x=>x.Id).ToList();
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public int GetParksCountAll()
        {
            int result = 0;
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Parks.Count(x => x.Active == true);
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }
        public int GetParksCountAll(ParkQueryDto parkQueryDto)
        {
            int result = 0;
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var ids = parkQueryDto.AutoClass.Select(x=>x.SelectAutoId);
                    var datacars = db.Cars.Where(x =>
                                    x.Active == true
                                    && ids.Contains(x.CatalogAutoClassId))
                                    .AsQueryable();

                    var parks = (from park in db.Parks
                                join car in datacars on park.Id equals car.ParkId
                                where park.Ransom == parkQueryDto.Ransom
                                && park.Active == true
                                group park by park.Id into g
                                select  new { g.Key }).ToList();
                    result = parks.Count();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<DriversConstraintTruncated> GetParksDriversConstraint(string parkGuid)
        {
            var result = new List<DriversConstraintTruncated>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.ParksDriversConstraints
                    .Where(x => x.ParkGuid == parkGuid)
                    .Select(u=> new DriversConstraintTruncated
                    {
                        Id = u.Id,
                        DriveName = (from drive in db.DriversConstraints
                                     where drive.Id == u.DriversConstraintId
                                     select drive.Name).FirstOrDefault() ?? string.Empty,

                    })
                    .ToList();
                result = parks;
            }
            return result;
        }

        public IEnumerable<WorkConditionTruncated> GetParksWorkConditionTruncated(string parkGuid)
        {
            var result = new List<WorkConditionTruncated>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.ParksWorkConditions
                    .Where(x => x.ParkGuid == parkGuid)
                    .Select(u => new WorkConditionTruncated
                    {
                        Id = u.Id,
                        WorkName = (from drive in db.WorkConditions
                                     where drive.Id == u.WorkConditionId
                                     select drive.Name).FirstOrDefault() ?? string.Empty,

                    })
                    .ToList();
                result = parks;
            }
            return result;
        }
        public int GetCarsCountAll(int parkId)
        {
            int result = 0;
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.Cars.Count(x=>x.ParkId == parkId 
                    && x.Active == true
                    && x.IsCarsGiven == false);
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public int GetFilterCountAll(int userId)
        {
            int result = 0;
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.UsersFilters.Count(x => x.FilterUserId == userId
                    && x.Active == true
                    );
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public IEnumerable<Car> GetCar()
        {
            var result = new List<Car>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.Cars.ToList();
                result = parks;
            }
            return result;
        }

        public IEnumerable<Car> GetCar(int parkId)
        {
            var result = new List<Car>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.Cars.Where(x=>x.ParkId == parkId).ToList();
                result = parks;
            }
            return result;
        }

        public IEnumerable<CarDto> GetCar(int parkId, int rows, int page)
        {
            var result = new List<CarDto>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var cars = db.Cars.Where(x => x.ParkId == parkId
                 && x.Active == true
                && x.IsCarsGiven == false)
                    .Select(x=> new CarDto
                    {
                        Id = x.Id,
                        CarName = x.CarName,
                        ClassName = (from data in db.CatalogAutoClasses
                                       where data.Id == x.CatalogAutoClassId
                                       select data.RName).FirstOrDefault(),
                        Color = x.Color,
                        Model = x.Model,
                        Number = x.Number,
                        PriceForDay = x.PriceForDay,
                        ShemaName = (from data in db.Schems
                                     where data.Id == x.SchemId
                                     select data.Name).FirstOrDefault(),
                        Year = x.Year

                    })
                    .OrderBy(b => b.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .ToList();
                result = cars;
            }
            return result;
        }

        public Driver GetDrivers(int id)
        {
            var result = new Driver();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var drive = db.Drivers.FirstOrDefault(x => x.Id == id
                 && x.Active == true);                                    
                result = drive;
            }
            return result;
        }

        public Offer GetOffer(int id)
        {
            var result = new Offer();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var offer = db.Offers.FirstOrDefault(x => x.Id == id
                 && x.Active == true);
                result = offer;
            }
            return result;
        }

        public UsersFilter GetUsersFilter(int id)
        {
            var result = new UsersFilter();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.UsersFilters.FirstOrDefault(x => x.Id == id
                 && x.Active == true
                 );
                result = data;
            }
            return result;
        }

        public IEnumerable<UsersFilter> GetUsersFilterToUserId(int userId)
        {
            var result = new List<UsersFilter>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.UsersFilters.Where(x => x.FilterUserId == userId
                 && x.Active == true
                 );
                result = data.ToList();
            }
            return result;
        }
        public int GetSelectParkCount(int userId)
        {
            int result = 0;
            try
            {
                using (TaxiAdministrationContext db = new TaxiAdministrationContext())
                {
                    var parks = db.SelectParks.Count(x=>x.UserId == userId
                    && x.Active == true);
                    result = parks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Processing {0}", ex.Message);
            }
            return result;
        }

        public SelectPark GetSelectPark(int selectPark, int userId)
        {
            var result = new SelectPark();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectParks.FirstOrDefault(x => 
                x.UserId == userId
                && x.ParkId == selectPark
                 && x.Active == true);
                result = data;
            }
            return result;
        }

        public IEnumerable<SelectPark> GetSelectPark(int userId)
        {
            var result = new List<SelectPark>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectParks.Where(x => x.UserId == userId
                 && x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<DriversConstraint> GetDriversConstraint()
        {
            var result = new List<DriversConstraint>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.DriversConstraints.Where(x=> x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<WorkCondition> GetWorkCondition()
        {
            var result = new List<WorkCondition>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.WorkConditions.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<DepositRet> GetDepositRet()
        {
            var result = new List<DepositRet>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.DepositRets.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<Locatioin1> GetLocation()
        {
            var result = new List<Locatioin1>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.Locatioin1s.ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<Locatioin1> GetLocation1()
        {
            var result = new List<Locatioin1>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.Locatioin1s.ToList();
                result = data;
            }
            return result;
        }
        public IEnumerable<Inspection> GetInspection()
        {
            var result = new List<Inspection>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.Inspections.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<Waybill> GetWaybill()
        {
            var result = new List<Waybill>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.Waybills.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<WorkRadius> GetWorkRadius()
        {
            var result = new List<WorkRadius>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.WorkRadii.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<MinRentalPeriod> GetMinRentalPeriod()
        {
            var result = new List<MinRentalPeriod>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.MinRentalPeriods.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<FirstDay> GetFirstDay()
        {
            var result = new List<FirstDay>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.FirstDays.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public IEnumerable<CatalogAutoClass> GetAutoClass()
        {
            var result = new List<CatalogAutoClass>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.CatalogAutoClasses.Where(x => x.Active == true).ToList();
                result = data;
            }
            return result;
        }

        public bool DeleteSelectPark(int selectParkId, int userId)
        {
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectParks.FirstOrDefault(
                    x => x.ParkId == selectParkId
                    && x.UserId == userId
                    && x.Active == true);
                if (data == null)
                {
                    return false;
                }
                data.Active = false;
                db.SelectParks.Attach(data);                
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserFilter(int id)
        {
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.UsersFilters.FirstOrDefault(
                    x => x.Id == id
                    && x.Active == true);
                if (data == null)
                {
                    return false;
                }
                data.Active = false;
                db.UsersFilters.Attach(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<CarsPicture> GetCarsPicture()
        {
            var result = new List<CarsPicture>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.CarsPictures.ToList();
                var carspic = new List<CarsPicture>();
                foreach (var p in parks) {
                    carspic.Add(new CarsPicture
                    { Id = p.Id,
                    CarId = p.CarId,
                    Picture = p.Picture
                    
                    
                    });

                }
                result = carspic;
            }
            return result;
        }


        public UserToken InsertUserToken(UserToken user)
        {
            var result = new UserToken();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                db.UserTokens.Add(user);
                db.Entry(user).State = EntityState.Added;
                db.SaveChanges();
                result = user;
                int id = user.Id;                
            }
            return result;
        }

        public User InsertUser(User user) 
        {
            var result = new User();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                db.Users.Add(user);
                db.Entry(user).State = EntityState.Added;
                db.SaveChanges();
                result = user;
                int id = user.Id;
            }
            return result;
        }
        public SelectPark InsertSelectPark(SelectPark selectPark) 
        {
            var result = new SelectPark();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var sp = db.SelectParks.FirstOrDefault(x=>
                x.ParkId == selectPark.ParkId 
                && x.UserId == selectPark.UserId
                && x.Active == true);
                if (sp != null)
                {
                    return sp;
                }
                db.SelectParks.Add(selectPark);
                db.Entry(selectPark).State = EntityState.Added;
                db.SaveChanges();
                result = selectPark;
                int id = selectPark.Id;
            }
            return result;
        }

        public Driver CreateUpdateDriver(Driver driver)
        {
            var result = new Driver();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var driv = db.Drivers.FirstOrDefault(x =>
                x.Fam == driver.Fam
                && x.Im == driver.Im
                && x.Ot == driver.Ot
                && x.Dr == driver.Dr
                && x.Phone == driver.Phone);
                if (driv != null)
                {
                    db.Drivers.Update(driv);
                    db.Entry(driv).State = EntityState.Modified;
                }
                else
                {
                    db.Drivers.Add(driver);
                    db.Entry(driver).State = EntityState.Added;                    
                }                
                
                db.SaveChanges();
                if (driv != null)
                {
                    result = driv;
                }
                else
                {
                    result = driver;
                }
            }
            return result;
        }

        public Offer CreateUpdateOffer(Offer offer)
        {
            var result = new Offer();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                db.Offers.Add(offer);
                db.Entry(offer).State = EntityState.Added;

                db.SaveChanges();
                result = offer;               
            }
            return result;
        }

        public SelectAutoClass CreateSelectAutoClass(SelectAutoClass selectAutoClass)
        {
            var result = new SelectAutoClass();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectAutoClasses.FirstOrDefault(x=>
                    x.AutoClassId == selectAutoClass.AutoClassId
                    && x.UserId == selectAutoClass.UserId
                    && x.UserFilterId == selectAutoClass.UserFilterId
                    && x.Active == true);
                if (data != null)
                {
                    return data;
                }
                db.SelectAutoClasses.Add(selectAutoClass);
                db.Entry(selectAutoClass).State = EntityState.Added;

                db.SaveChanges();
                result = selectAutoClass;
            }
            return result;
        }

        public bool DeleteSelectAutoClass(SelectAutoClass selectAutoClass)
        {            
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectAutoClasses.Where(x =>                   
                    x.UserId == selectAutoClass.UserId
                    && x.UserFilterId == selectAutoClass.UserFilterId
                    && x.Active == true);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        item.Active = false;
                        db.SelectAutoClasses.Update(item);
                    }
                }   
                db.SaveChanges();                
            }
            return true;
        }

        public SelectLocationFilter CreateSelectLocationFilter(SelectLocationFilter selectLocationFilter)
        {
            var result = new SelectLocationFilter();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectLocationFilters.FirstOrDefault(x =>
                       x.LocationId   == selectLocationFilter.LocationId
                    && x.UserId       == selectLocationFilter.UserId
                    && x.UserFilterId == selectLocationFilter.UserFilterId
                    && x.Active       == true);
                if (data != null)
                {
                    return data;
                }
                db.SelectLocationFilters.Add(selectLocationFilter);
                db.Entry(selectLocationFilter).State = EntityState.Added;

                db.SaveChanges();
                result = selectLocationFilter;
            }
            return result;
        }

        public bool DeleteSelectLocationFilter(SelectLocationFilter selectLocationFilter)
        {
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectLocationFilters.Where(x =>
                    x.UserId == selectLocationFilter.UserId
                    && x.UserFilterId == selectLocationFilter.UserFilterId
                    && x.Active == true);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        item.Active = false;
                        db.SelectLocationFilters.Update(item);
                    }                    
                }              

                db.SaveChanges();            
            }
            return true;
        }

        public UsersFilter CreateUpdateUsersFilter(UsersFilter usersFilter)
        {
            var result = new UsersFilter();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                if (usersFilter.Id != null && usersFilter.Id != 0)
                {
                    var data = db.UsersFilters.FirstOrDefault(
                        x => x.Id == usersFilter.Id
                        && x.Active == true);
                    if (data != null)
                    {
                        data.AddressLatitude = usersFilter.AddressLatitude;
                        data.AddressLongitude = usersFilter.AddressLongitude;
                        data.ParkPercent = usersFilter.ParkPercent;
                        data.FilterName = usersFilter.FilterName;
                        data.FilterUserId = usersFilter.FilterUserId;
                        data.IsPush = usersFilter.IsPush;
                        data.Ransom = usersFilter.Ransom;

                        db.UsersFilters.Update(data);
                        db.Entry(data).State = EntityState.Modified;
                    }
                }
                else {
                    db.UsersFilters.Add(usersFilter);
                    db.Entry(usersFilter).State = EntityState.Added;
                }

                db.SaveChanges();
                result = usersFilter;
            }
            return result;
        }

        public List<SelectLocation> GetSelectLocationFilter(int userId, int filterId)
        {
            var result = new List<SelectLocation>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectLocationFilters.Where(x =>
                    x.UserId == userId
                    && x.UserFilterId == filterId
                    && x.Active == true).Select(x => 
                    new SelectLocation 
                    { Id = x.Id, 
                        SelectLocationId= x.LocationId,
                        NameLocation = (from loc in db.Locatioin1s
                                    where loc.CatId == x.LocationId
                                    select loc.CatName).FirstOrDefault()
                    }).ToList();
                if (data != null)
                {
                    return data;
                }
            }
            return result;
        }

        public List<SelectAuto> GetSelectAutoFilter(int userId, int filterId)
        {
            var result = new List<SelectAuto>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.SelectAutoClasses.Where(x =>
                    x.UserId == userId
                    && x.UserFilterId == filterId
                    && x.Active == true).Select(x => new SelectAuto { Id = x.Id, SelectAutoId = x.AutoClassId }).ToList();
                if (data != null)
                {
                    return data;
                }
            }
            return result;
        }

        public bool FilterIsPush(int filterId, bool push)
        {
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var data = db.UsersFilters.FirstOrDefault(x=>x.Id == filterId);
                if (data == null)return false;
                data.IsPush = push;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUser(string defaultPhone, string defaultEmail)
        {
            var result = new User();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var user = db.Users.FirstOrDefault(x=>x.DefaultPhone == defaultPhone && x.DefaultEmail == defaultEmail);
                result = user;                
            }
            return result;
        }

        public RoutePage CreateRoutePage(RoutePage routePage)
        {
            var result = new RoutePage();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                db.RoutePages.Add(routePage);
                db.Entry(routePage).State = EntityState.Added;

                db.SaveChanges();
                result = routePage;
            }
            return result;
        }
    }
}
