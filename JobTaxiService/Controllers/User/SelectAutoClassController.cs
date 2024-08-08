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

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] SelectAutoClassDto selectAutoClassDto)
        {
            var result = new SelectAutoClass();
            _logger.LogInformation("CreateSelectAutoClass");
            try 
            {   
                var resultdata = _jobRepository.CreateSelectAutoClass(new SelectAutoClass
                {
                    AutoClassId = selectAutoClassDto.AutoClassId,
                    UserId = selectAutoClassDto.UserId,
                    UserFilterId = selectAutoClassDto.UserFilterId,
                });
                result = resultdata;

                return new ObjectResult(resultdata) { StatusCode = StatusCodes.Status201Created }; 
            } 
            catch { return new ObjectResult(result) { StatusCode = StatusCodes.Status502BadGateway }; }
            
        }
    }
}