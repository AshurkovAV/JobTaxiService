using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.Nsi;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
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
        public async Task<IEnumerable<WorkConditionDto>> Get()
        {
            var result = new List<WorkConditionDto>();
            _logger.LogInformation("GetWorkCondition");
            var resultData = _jobRepository.GetWorkCondition();
            foreach (var item in resultData)
            {
                result.Add(new WorkConditionDto
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }            
            return result;
        }
    }
}