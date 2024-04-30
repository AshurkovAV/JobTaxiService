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
                    CarId = p.CarId
                    
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

        public User GetUser(string deviceId)
        {
            var result = new User();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var user = db.Users.FirstOrDefault(x=>x.DeviceId == deviceId);
                result = user;                
            }
            return result;
        }
    }
}
