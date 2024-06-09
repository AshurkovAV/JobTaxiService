using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers.Tpark
{
    [ApiController]
    [Route("park/[controller]")]
    public class WorkConditionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public WorkConditionController(
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
        public async Task<IEnumerable<WorkConditionTruncated>> Get(string parkGuid)
        {
            var result = new List<WorkConditionTruncated>();
            _logger.LogInformation("GetParksWorkCondition");
            var resultCar = _jobRepository.GetParksWorkConditionTruncated(parkGuid);
            result = resultCar.ToList();
            return result;
        }
    }
}