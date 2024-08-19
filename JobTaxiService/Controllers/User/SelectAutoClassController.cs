using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto.User;

namespace JobTaxiService.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class SelectAutoClassController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public SelectAutoClassController(
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
        public async Task<List<SelectAuto>> Get(int userId, int filterId)
        {
            var result = new List<SelectAuto>();
            _logger.LogInformation("GetGetSelectAutoFilter");
            var resultData = _jobRepository.GetSelectAutoFilter(userId, filterId);
            result = resultData;
            return result;
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] SelectAutoClassDto selectAutoClassDto)
        {
            var result = new List<SelectAutoClass>();
            _logger.LogInformation("CreateSelectAutoClass");
            try 
            {
                foreach (var item in selectAutoClassDto.AutoClassIds)
                {
                    var resultdata = _jobRepository.CreateSelectAutoClass(new SelectAutoClass
                    {
                        AutoClassId = item,
                        UserId = selectAutoClassDto.UserId,
                        UserFilterId = selectAutoClassDto.UserFilterId,
                    });
                    result.Add(resultdata);
                }

                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created }; 
            } 
            catch { return new ObjectResult(result) { StatusCode = StatusCodes.Status502BadGateway }; }
            
        }
    }
}