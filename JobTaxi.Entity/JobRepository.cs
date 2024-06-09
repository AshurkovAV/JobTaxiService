using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                                         select car ).Count(),                            

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
                    var parks = db.Parks.Count();
                    result = parks;
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

        public IEnumerable<Car> GetCar(int parkId, int rows, int page)
        {
            var result = new List<Car>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var cars = db.Cars.Where(x => x.ParkId == parkId
                 && x.Active == true
                && x.IsCarsGiven == false)
                    .OrderBy(b => b.Id)
                        .Skip((page - 1) * rows) //пропускает определенное количество элементов Страница
                        .Take(rows) //извлекает определенное число элементов
                        .ToList();
                result = cars;
            }
            return result;
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
                db.SelectParks.Add(selectPark);
                db.Entry(selectPark).State = EntityState.Added;
                db.SaveChanges();
                result = selectPark;
                int id = selectPark.Id;
            }
            return result;
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
    }
}
