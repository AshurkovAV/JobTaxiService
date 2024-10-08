using JobTaxi.Entity;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto.Nsi;

namespace JobTaxiService.Controllers.Nsi
{
    [ApiController]
    [Route("nsi/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public LocationController(
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
        public async Task<IEnumerable<LocationDto>> Get()
        {
            var result = new List<LocationDto>();
            _logger.LogInformation("GetLocationDto");
            var resultData = _jobRepository.GetLocation();
            foreach (var item in resultData)
            {
                result.Add(new LocationDto
                {
                    Id = item.CatId,
                    OblName = item.CatName                    
                });
            }
            return result;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("j/")]
        public async Task<IEnumerable<Location1Dto>> GetLocation1()
        {
            var result = new List<Location1Dto>();
            _logger.LogInformation("GetLocation1Dto");
            var resultData = _jobRepository.GetLocation1();
            foreach (var item in resultData)
            {
                result.Add(new Location1Dto
                {
                    CatId = item.CatId,
                    Cats = item.Cats                    
                });
            }
            return result;
        }
        [HttpGet]
        [Produces("application/json")]
        [Route("obl/nav")]
        public async Task<IEnumerable<Location1Dto>> GetLocationOblast(int rows, int page)
        {
            var result = new List<Location1Dto>();
            _logger.LogInformation("GetLocation1Dto");
            var resultData = _jobRepository.GetLocation1(rows, page);
            foreach (var item in resultData)
            {
                result.Add(new Location1Dto
                {
                    CatId = item.CatId,
                    Cats = item.CatName
                });
            }
            return result;
        }

        [HttpGet]
        [Route("gor/nav")]
        public async Task<IEnumerable<Location1Dto>> GetLocationGorod(int rows, int page)
        {
            var result = new List<Location1Dto>();
            _logger.LogInformation("GetLocation1Dto");
            var resultData = _jobRepository.GetLocationGorod(rows, page);
            foreach (var item in resultData)
            {
                result.Add(new Location1Dto
                {
                    CatId = item.GorId,
                    Cats = item.GorName
                });
            }
            return result;
        }
    }
}