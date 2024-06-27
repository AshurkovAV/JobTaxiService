using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Models;

namespace JobTaxi.Entity
{
    public interface IJobRepository
    {
        public IEnumerable<Park> GetParks();
        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page);
        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page, int userId);
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
        public bool DeleteSelectPark(int selectParkId, int userId);
        public Driver GetDrivers(int id);
        public IEnumerable<SelectPark> GetSelectPark(int userId);
        public SelectPark GetSelectPark(int selectPark, int userId);
        public int GetSelectParkCount(int userId);
        public Driver CreateUpdateDriver(Driver driver);

        public Offer GetOffer(int id);
        
        public Offer CreateUpdateOffer(Offer offer);

        public IEnumerable<DriversConstraint> GetDriversConstraint();
        public IEnumerable<WorkCondition> GetWorkCondition();
    }
}
