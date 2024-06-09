using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers.Tpark
{
    [ApiController]
    [Route("park/[controller]")]
    public class DriversConstraintController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public DriversConstraintController(
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
        public async Task<IEnumerable<ParksDriversConstraint>> Get(string parkGuid)
        {
            var result = new List<ParksDriversConstraint>();
            _logger.LogInformation("GetParksDriversConstraint");
            var resultCar = _jobRepository.GetParksDriversConstraint(parkGuid);
            result = resultCar.ToList();
            return result;
        }
    }
}