﻿using JobTaxi.Entity.Dto;
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
        public IEnumerable<CarsPicture> GetCarsPicture();
        public UserToken InsertUserToken(UserToken user);
        public User InsertUser(User user);
        public User GetUser(string defaultPhone, string defaultEmail);
    }
}
