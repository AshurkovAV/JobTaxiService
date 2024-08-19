using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
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

        [HttpGet]
        [Produces("application/json")]
        public async Task<List<SelectLocation>> Get(int userId, int filterId)
        {
            var result = new List<SelectLocation>();
            _logger.LogInformation("GetSelectLocationFilter");
            var resultData = _jobRepository.GetSelectLocationFilter(userId, filterId);
            result = resultData;
            return result;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] SelectLocationFilterDto selectLocationFilterDto)
        {
            var result = new List<SelectLocationFilter>();
            _logger.LogInformation("CreateSelectLocationFilter");
            try 
            {
                foreach (var item in selectLocationFilterDto.LocationIds)
                {
                    var resultdata = _jobRepository.CreateSelectLocationFilter(new SelectLocationFilter
                    {
                        LocationId = item,
                        UserId = selectLocationFilterDto.UserId,
                        UserFilterId = selectLocationFilterDto.UserFilterId,
                    });
                    result.Add(resultdata);
                }
                

                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created }; 
            } 
            catch { return new ObjectResult(result) { StatusCode = StatusCodes.Status502BadGateway }; }
            
        }
    }
}