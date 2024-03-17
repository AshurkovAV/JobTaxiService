using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;

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
                    _logger.LogInformation("GetCarsPicture");
                }
            }
            result = (List<Park>)resultParks;
            return result;
        }
    }
}