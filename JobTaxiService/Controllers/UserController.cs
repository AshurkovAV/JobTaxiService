using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using JobTaxiService.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        public UserController(IJobRepository jobRepository) {
            _jobRepository = jobRepository;
        }

        [Produces("application/json")]        
        [HttpPost]
        public async Task<IActionResult> Get(string deviceId, string token)
        {
            Console.WriteLine("Добавление пользователя");
            try
            {
                if (token != "631DFC6B-5080-4E4B-BBDD-2E74DEFA8025") 
                {
                    return StatusCode(401);
                }                
                var user = _jobRepository.GetUser(deviceId);
                return new JsonResult(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(502);
            }
        }        
    }
}
