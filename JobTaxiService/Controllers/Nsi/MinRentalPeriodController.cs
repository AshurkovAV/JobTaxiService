using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
    public class MinRentalPeriodController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public MinRentalPeriodController(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        //[HttpGet]
        //[Produces("application/json")]
        //public async Task<IEnumerable<MinRe>> Get()
        //{
        //    var result = new List<WorkRadius>();
        //    _logger.LogInformation("GetWorkRadius");
        //    var resultData = _jobRepository.GetWorkRadius();
        //    result = resultData.ToList();
        //    return result;
        //}
    }
}