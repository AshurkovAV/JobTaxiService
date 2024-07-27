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
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<SelectParkDto>> Get(int userId)
        {
            var result = new List<SelectParkDto>();
            _logger.LogInformation("GetSelectPark");
            var resultData = _jobRepository.GetSelectPark(userId);
            foreach (var item in resultData) {
                result.Add(new SelectParkDto {
                    ParkId = item.ParkId,
                    UserId = item.UserId,
                });
            }            
            return result;
        }
        [HttpGet]
        [Produces("application/json")]
        [Route("sp")]
        public async Task<SelectParkDto> Get(int selectParkId, int userId)
        {
            var result = new SelectParkDto();
            _logger.LogInformation("GetSelectPark");
            var resultData = _jobRepository.GetSelectPark(selectParkId, userId);
            if (resultData?.Id != null)
            {
                result = new SelectParkDto
                {
                    ParkId = resultData.ParkId,
                    UserId = resultData.UserId,
                };
            }
           
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("count/")]
        public async Task<int> GetCount(int userId)
        {
            _logger.LogInformation("GetSelectParkCount");
            var resultParks = _jobRepository.GetSelectParkCount(userId);
            return resultParks;
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
        [HttpPost]
        [Produces("application/json")]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] SelectParkDto select)
        {
            try
            {
                _logger.LogInformation("DeleteSelectPark");
                var selectPark = _jobRepository.DeleteSelectPark(select.ParkId, select.UserId);
                if (selectPark)
                { return new ObjectResult(true) { StatusCode = StatusCodes.Status200OK }; }
                else
                {
                    return new ObjectResult(false) { StatusCode = StatusCodes.Status400BadRequest };
                }
            } 
            catch {
                return new ObjectResult(false) { StatusCode = StatusCodes.Status400BadRequest }; ;
            }
            
        }
    }
}