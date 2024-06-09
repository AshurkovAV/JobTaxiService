using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public CarController(
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
        public async Task<IEnumerable<Car>> Get(int parkId)
        {
            var result = new List<Car>();
            _logger.LogInformation("GetCar");
            var resultCar = _jobRepository.GetCar(parkId);
            
            foreach (var car in resultCar)
            {
                var carsPictures = _jobRepository.GetCarsPicture().Where(x => x.CarId == car.Id).ToList();
                car.CarsPictures = carsPictures;
                result = (List<Car>)resultCar;
                return result;
            }
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("nav")]
        public async Task<IEnumerable<Car>> GetNav(int parkId, int rows, int page)
        {
            var result = new List<Car>();
            _logger.LogInformation("GetCarNav");
            var resultCar = _jobRepository.GetCar(parkId, rows, page);

            foreach (var car in resultCar)
            {
                //var carsPictures = _jobRepository.GetCarsPicture().Where(x => x.CarId == car.Id).ToList();
                //car.CarsPictures = carsPictures;
                result = (List<Car>)resultCar;
                return result;
            }
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("count/")]
        public async Task<int> GetCount(int parkId)
        {
            _logger.LogInformation("GetCarCount");
            var resultCars = _jobRepository.GetCarsCountAll(parkId);
            return resultCars;
        }
    }
}