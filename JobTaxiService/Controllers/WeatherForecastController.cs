using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Models;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Park> Get()
        {
            var result = new List<Park>();
            using (TaxiAdministrationContext db = new TaxiAdministrationContext())
            {
                // �������� ������� �� �� � ������� �� �������
                var parks = db.Parks.ToList();
                Console.WriteLine("������ �����������:");
                result = parks;
               
            }         
            return result;            
        }
    }
}