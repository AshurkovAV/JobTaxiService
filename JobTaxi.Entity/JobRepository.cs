using JobTaxi.Entity.Models;

namespace JobTaxi.Entity
{
    public class JobRepository : IJobRepository
    {
        public IEnumerable<CatalogAutoClass> GetCatalogAutoClasses()
        {
            var result = new List<CatalogAutoClass>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.CatalogAutoClasses.ToList();
                result = parks;
            }
            return result;
        }

        public IEnumerable<Park> GetParks()
        {
            var result = new List<Park>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                var parks = db.Parks.ToList();
                result = parks;
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
                result = parks;
            }
            return result;
        }
    }
}
