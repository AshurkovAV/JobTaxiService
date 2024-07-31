using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxiService.Dto;
using JobTaxi.Entity.Dto.User;

namespace JobTaxiService.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class UsersFilterController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public UsersFilterController(
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
        public async Task<UsersFilter> Get(int id)
        {
            var result = new UsersFilter();
            _logger.LogInformation("GetUsersFilter");
            var resultOffer = _jobRepository.GetUsersFilter(id);
            result = resultOffer;
            return result;
        }

        

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] UsersFilterDto usersFilterDto)
        {
            try
            {
                var result = new UsersFilterDto();
                _logger.LogInformation("CreateUsersFilter");
                var resultData = _jobRepository.CreateUpdateUsersFilter(new UsersFilter
                {
                    FilterName = usersFilterDto.FilterName,
                    AddressLatitude = usersFilterDto.AddressLatitude,
                    AddressLongitude = usersFilterDto.AddressLongitude,
                    ParkPercent = usersFilterDto.ParkPercent,

                });
                usersFilterDto.Id = resultData.Id;
                result = usersFilterDto;
                return new ObjectResult(resultData) { StatusCode = StatusCodes.Status201Created }; ;
            }
            catch (Exception ex)
            {
                
                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status502BadGateway };
            }
            
        }
    }
}