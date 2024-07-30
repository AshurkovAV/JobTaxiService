using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto.Nsi;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
    public class AutoClassController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public AutoClassController(
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
        public async Task<IEnumerable<AutoClassDto>> Get()
        {
            var result = new List<AutoClassDto>();
            _logger.LogInformation("GetAutoClassDto");
            var resultData = _jobRepository.GetAutoClass();
            foreach (var item in resultData)
            {
                result.Add(new AutoClassDto
                {
                    Id = item.Id,
                    Name = item.RName
                });
            }            
            return result;
        }
    }
}