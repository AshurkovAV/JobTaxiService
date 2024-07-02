using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto.Nsi;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
    public class DepositRetController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public DepositRetController(
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
        public async Task<IEnumerable<DepositRetDto>> Get()
        {
            var result = new List<DepositRetDto>();
            _logger.LogInformation("GetDepositRet");
            var resultData = _jobRepository.GetDepositRet();
            foreach (var item in resultData)
            {
                result.Add(new DepositRetDto 
                { 
                    Id = item.Id,
                    Name = item.Name
                });
            }            
            return result;
        }
    }
}