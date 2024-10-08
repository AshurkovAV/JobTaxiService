﻿using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.Nsi;
using JobTaxi.Entity.Dto.Park;
using JobTaxi.Entity.Dto.User;
using JobTaxi.Entity.Models;

namespace JobTaxi.Entity
{
    public interface IJobRepository
    {
        public IEnumerable<Park> GetParks();
        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page);
        public IEnumerable<ParkTruncated> GetParksTruncated(int rows, int page, int userId);
        public IEnumerable<ParkTruncated> GetParksTruncatedToUserId(int rows, int page, int userId);
        public int GetParksCountAll();
        public int GetParksCountAll(ParkQueryDto parkQueryDto);
        public IEnumerable<int> GetParksIdAll();
        public IEnumerable<CatalogAutoClass> GetCatalogAutoClasses();
        public IEnumerable<Car> GetCar();
        public IEnumerable<Car> GetCar(int parkId);
        public IEnumerable<CarDto> GetCar(int parkId, int rows, int page);
        public int GetCarsCountAll(int parkId);
        public IEnumerable<DriversConstraintTruncated> GetParksDriversConstraint(string parkGuid);
        public IEnumerable<WorkConditionTruncated> GetParksWorkConditionTruncated(string parkGuid);
        public IEnumerable<CarsPicture> GetCarsPicture();
        public UserToken InsertUserToken(UserToken user);
        public User InsertUser(User user);
        public User GetUser(string defaultPhone, string defaultEmail);
        public SelectPark InsertSelectPark(SelectPark selectPark);
        public bool DeleteSelectPark(int selectParkId, int userId);
        public bool DeleteUserFilter(int id);
        public Driver GetDrivers(int id);
        public IEnumerable<SelectPark> GetSelectPark(int userId);
        public SelectPark GetSelectPark(int selectPark, int userId);
        public int GetSelectParkCount(int userId);
        public Driver CreateUpdateDriver(Driver driver);
        public Offer GetOffer(int id);
        public UsersFilter GetUsersFilter(int id);
        public IEnumerable<UsersFilter> GetUsersFilterToUserId(int userId);
        public Offer CreateUpdateOffer(Offer offer);
        public SelectAutoClass CreateSelectAutoClass(SelectAutoClass selectAutoClass);
        public bool DeleteSelectAutoClass(SelectAutoClass selectAutoClass);
        public SelectLocationFilter CreateSelectLocationFilter(SelectLocationFilter selectLocationFilter);
        public bool DeleteSelectLocationFilter(SelectLocationFilter selectLocationFilter);
        public UsersFilter CreateUpdateUsersFilter(UsersFilter usersFilter);
        public bool FilterIsPush(int filterId, bool push);
        public int GetFilterCountAll(int userId);
        public IEnumerable<DriversConstraint> GetDriversConstraint();
        public IEnumerable<WorkCondition> GetWorkCondition();
        public IEnumerable<DepositRet> GetDepositRet();
        public IEnumerable<Locatioin1> GetLocation();
        public IEnumerable<Locatioin1> GetLocation1();
        public IEnumerable<Locatioin1> GetLocation1(int rows, int page);
        public IEnumerable<Location5> GetLocationGorod(int rows, int page);
        public IEnumerable<Inspection> GetInspection();
        public IEnumerable<Waybill> GetWaybill();
        public IEnumerable<WorkRadius> GetWorkRadius();
        public IEnumerable<MinRentalPeriod> GetMinRentalPeriod();        
        public IEnumerable<FirstDay> GetFirstDay();
        public IEnumerable<CatalogAutoClass> GetAutoClass();
        public RoutePage CreateRoutePage(RoutePage routePage);
        public List<SelectLocation> GetSelectLocationFilter(int userId, int filterId);
        public List<SelectAuto> GetSelectAutoFilter(int userId, int filterId);
    }
}
