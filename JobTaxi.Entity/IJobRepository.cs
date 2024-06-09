using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;

namespace JobTaxi.Entity
{
    public interface IJobRepository
    {
        public IEnumerable<Park> GetParks();
        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page);
        public int GetParksCountAll();
        public IEnumerable<int> GetParksIdAll();
        public IEnumerable<CatalogAutoClass> GetCatalogAutoClasses();
        public IEnumerable<Car> GetCar();
        public IEnumerable<Car> GetCar(int parkId);
        public IEnumerable<Car> GetCar(int parkId, int rows, int page);
        public int GetCarsCountAll(int parkId);
        public IEnumerable<DriversConstraintTruncated> GetParksDriversConstraint(string parkGuid);
        public IEnumerable<WorkConditionTruncated> GetParksWorkConditionTruncated(string parkGuid);
        public IEnumerable<CarsPicture> GetCarsPicture();
        public UserToken InsertUserToken(UserToken user);
        public User InsertUser(User user);
        public User GetUser(string defaultPhone, string defaultEmail);
        public SelectPark InsertSelectPark(SelectPark selectPark);
    }
}
