using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelectParkController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public SelectParkController(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {            
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] SelectParkDto select)
        {
            _logger.LogInformation("CreateSelectPark");           
            var selectPark = _jobRepository.InsertSelectPark(new SelectPark
            {
                ParkId = select.ParkId,
                UserId = select.UserId
            });
            
            return new ObjectResult(selectPark) { StatusCode = StatusCodes.Status201Created }; ;
        }        
    }
}