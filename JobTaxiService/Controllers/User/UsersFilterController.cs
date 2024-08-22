using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
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

        [HttpGet]
        [Produces("application/json")]
        [Route("us/")]
        public async Task<IEnumerable<UsersFilterDto>> GetToUserId(int userId)
        {
            var result = new List<UsersFilterDto>();
            _logger.LogInformation("GetUsersFilter");
            var resultData = _jobRepository.GetUsersFilterToUserId(userId);
            foreach (var item in resultData)
            {
                result.Add(new UsersFilterDto
                {
                    Id = item.Id,
                    FilterName = item.FilterName,
                    AddressLatitude = item.AddressLatitude, 
                    AddressLongitude = item.AddressLongitude,
                    FilterUserId = item.FilterUserId,
                    ParkPercent = item.ParkPercent,
                    IsPush = item.IsPush
                });
            }            
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("count/")]
        public async Task<int> GetCount(int userId)
        {
            _logger.LogInformation("GetFilterCount");
            var resultCars = _jobRepository.GetFilterCountAll(userId);
            return resultCars;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("ispush/")]
        public async Task<bool> Ispush(int id, bool push)
        {
            _logger.LogInformation("Ispush");
            var resultdata = _jobRepository.FilterIsPush(id, push);
            return resultdata;
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
                    Id = usersFilterDto.Id,
                    FilterName = usersFilterDto.FilterName,
                    AddressLatitude = usersFilterDto.AddressLatitude,
                    AddressLongitude = usersFilterDto.AddressLongitude,
                    ParkPercent = usersFilterDto.ParkPercent,
                    FilterUserId = usersFilterDto.FilterUserId,
                    IsPush = usersFilterDto.IsPush,
                    Ransom = usersFilterDto.Ransom,
                });

                if (usersFilterDto.AutoClass != null)
                {
                    if (usersFilterDto.Id != null && usersFilterDto.Id != 0)
                    {
                        var resultdata = _jobRepository.DeleteSelectAutoClass(new SelectAutoClass
                        {                          
                            UserId = usersFilterDto.FilterUserId,
                            UserFilterId = resultData.Id
                        });
                    }
                    foreach (var item in usersFilterDto.AutoClass)
                    {
                        var resultdata = _jobRepository.CreateSelectAutoClass(new SelectAutoClass
                        {
                            Id = item.Id,
                            AutoClassId = item.SelectAutoId,
                            UserId = usersFilterDto.FilterUserId,
                            UserFilterId = resultData.Id
                        });
                    }
                }
                if (usersFilterDto.LocationFilter != null)
                {
                    if (usersFilterDto.Id != null && usersFilterDto.Id != 0)
                    {
                        var resultdata = _jobRepository.DeleteSelectLocationFilter(new SelectLocationFilter
                        {
                            UserId = usersFilterDto.FilterUserId,
                            UserFilterId = resultData.Id
                        });
                    }

                    foreach (var item in usersFilterDto.LocationFilter)
                    {
                        var resultdata = _jobRepository.CreateSelectLocationFilter(new SelectLocationFilter
                        {
                            Id = item.Id,
                            LocationId = item.SelectLocationId,
                            UserId = usersFilterDto.FilterUserId,
                            UserFilterId = resultData.Id
                        });
                    }
                }
                usersFilterDto.Id = resultData.Id;
                result = usersFilterDto;
                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created }; ;
            }
            catch (Exception ex)
            {
                
                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status502BadGateway };
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("delete/")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteUsersFilter");
                var selectPark = _jobRepository.DeleteUserFilter(id);
                if (selectPark)
                { return new ObjectResult(true) { StatusCode = StatusCodes.Status200OK }; }
                else
                {
                    return new ObjectResult(false) { StatusCode = StatusCodes.Status400BadRequest };
                }
            }
            catch
            {
                return new ObjectResult(false) { StatusCode = StatusCodes.Status400BadRequest }; ;
            }

        }
    }
}