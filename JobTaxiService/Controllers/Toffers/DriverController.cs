using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers.Toffers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public DriverController(
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
        public async Task<Driver> Get(int id)
        {
            var result = new Driver();
            _logger.LogInformation("GetDrivers");
            var resultCar = _jobRepository.GetDrivers(id);
            result = resultCar;
            return result;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] DriverDto driver)
        {
            var result = new Driver();
            _logger.LogInformation("CreateDrivers");
            var resultDriver = _jobRepository.CreateUpdateDriver(new Driver 
            {
                Fam = driver.Fam,
                Im = driver.Im,
                Ot = driver.Ot,
                Dr = driver.Dr,
                Phone = driver.Phone,
            });
            result = resultDriver;
            return new ObjectResult(resultDriver) { StatusCode = StatusCodes.Status201Created }; ;
        }
    }
}