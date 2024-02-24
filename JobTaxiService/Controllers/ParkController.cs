using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkController : ControllerBase
    {
        private readonly ILogger<ParkController> _logger;
        private readonly IJobRepository _jobRepository;
        public ParkController(ILogger<ParkController> logger,
            IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Park>> Get()
        {
            var result = new List<Park>();
            var resultParks = _jobRepository.GetParks();
            foreach (var park in resultParks)
            {
                var cars = _jobRepository.GetCar().Where(x=>x.ParkId == park.Id).ToList();
                park.Cars = cars;
                foreach (var car in cars) {
                    var carsPictures = _jobRepository.GetCarsPicture().Where(x => x.CarId == car.Id).ToList();
                    car.CarsPictures = carsPictures;                    
                }
            }
            result = (List<Park>)resultParks;
            return result;
        }
    }
}