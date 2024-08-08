using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;

namespace JobTaxiService.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class SelectLocationFilterController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public SelectLocationFilterController(
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
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] SelectLocationFilterDto selectLocationFilterDto)
        {
            var result = new SelectLocationFilter();
            _logger.LogInformation("CreateSelectLocationFilter");
            try 
            {   
                var resultdata = _jobRepository.CreateSelectLocationFilter(new SelectLocationFilter
                {
                    LocationId = selectLocationFilterDto.LocationId,
                    UserId = selectLocationFilterDto.UserId,
                    UserFilterId = selectLocationFilterDto.UserFilterId,
                });
                result = resultdata;

                return new ObjectResult(resultdata) { StatusCode = StatusCodes.Status201Created }; 
            } 
            catch { return new ObjectResult(result) { StatusCode = StatusCodes.Status502BadGateway }; }
            
        }
    }
}