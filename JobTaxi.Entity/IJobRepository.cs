using JobTaxi.Entity.Models;

namespace JobTaxi.Entity
{
    public interface IJobRepository
    {
        public IEnumerable<Park> GetParks();
        public IEnumerable<CatalogAutoClass> GetCatalogAutoClasses();
        public IEnumerable<Car> GetCar();
        public IEnumerable<CarsPicture> GetCarsPicture();
    }
}
