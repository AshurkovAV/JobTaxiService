using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto.Nsi;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
    public class WaybillsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public WaybillsController(
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
        public async Task<IEnumerable<WaybillsDto>> Get()
        {
            var result = new List<WaybillsDto>();
            _logger.LogInformation("GetWaybill");
            var resultData = _jobRepository.GetWaybill();
            foreach (var item in resultData)
            {
                result.Add(new WaybillsDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }            
            return result;
        }
    }
}