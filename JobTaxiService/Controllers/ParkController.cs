using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public ParkController(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {            
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Park>> Get()
        {
            var result = new List<Park>();
            _logger.LogInformation("GetPark");
            var resultParks = _jobRepository.GetParks();
            _logger.LogInformation(resultParks.Count().ToString());
            foreach (var park in resultParks)
            {
                var cars = _jobRepository.GetCar().Where(x=>x.ParkId == park.Id).ToList();
                _logger.LogInformation(park.ParkName);
                park.Cars = cars;
                foreach (var car in cars) {
                    var carsPictures = _jobRepository.GetCarsPicture().Where(x => x.CarId == car.Id).ToList();
                    car.CarsPictures = carsPictures;
                    //_logger.LogInformation("GetCarsPicture");
                }
            }
            result = (List<Park>)resultParks;
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("truncated/")]
        public async Task<IEnumerable<ParkTruncated>> GetTruncated(int rows, int page)
        {
            var result = new List<ParkTruncated>();
            _logger.LogInformation("GetParksTruncated");
            var resultParks = _jobRepository.GetParksTruncated(rows, page);
            //foreach (var park in resultParks)
            //{
            //    var cars = _jobRepository.GetCar(park.Id);
            //    if(cars != null)
            //    {
            //        park.Cars = new List<Car>();
            //        park.Cars.AddRange(cars);
            //        //park.CarAvatar = _jobRepository.GetCarsPicture()?.FirstOrDefault(x => x.CarId == cars.Id)?.Picture;
            //    }
            //}

            result = (List<ParkTruncated>)resultParks;
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("truncated/user")]
        public async Task<IEnumerable<ParkTruncated>> GetTruncated(int rows, int page, int userId)
        {
            var result = new List<ParkTruncated>();
            _logger.LogInformation("GetParksTruncated");
            var resultParks = _jobRepository.GetParksTruncated(rows, page, userId);           

            result = (List<ParkTruncated>)resultParks;
            return result;
        }


        [HttpGet]
        [Produces("application/json")]
        [Route("id/")]
        public async Task<List<int>> GetId()
        {
            var result = new List<int>();
            _logger.LogInformation("GetIdParks");
            var resultParks = _jobRepository.GetParksIdAll();                        
            result = (List<int>)resultParks;
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("count/")]
        public async Task<int> GetCount()
        {
            _logger.LogInformation("GetParkCount");
            var resultParks = _jobRepository.GetParksCountAll();
            return resultParks;
        }
    }
}