using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxiService.Dto;

namespace JobTaxiService.Controllers.Toffers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public OfferController(
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
        public async Task<Offer> Get(int id)
        {
            var result = new Offer();
            _logger.LogInformation("GetOffer");
            var resultOffer = _jobRepository.GetOffer(id);
            result = resultOffer;
            return result;
        }

        

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] OfferDto offer)
        {
            var result = new Offer();
            _logger.LogInformation("CreateOffer");
            var resultOffer = _jobRepository.CreateUpdateOffer(new Offer 
            {
                ParkId = offer.ParkId,
                DriverId = offer.DriverId,                
            });
            result = resultOffer;
            return new ObjectResult(resultOffer) { StatusCode = StatusCodes.Status201Created }; ;
        }
    }
}