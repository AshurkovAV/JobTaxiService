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
                            ParkName = x.ParkName,
                            ParkAddress = x.ParkAddress,
                            ParkPhone = x.ParkPhone,
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
