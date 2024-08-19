using JobTaxi.Entity;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;

namespace JobTaxiService.Controllers.Toffers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadFileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public DownloadFileController(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Since this is just and example, I am using a local file located inside wwwroot
            // Afterwards file is converted into a stream
            string pathRoot = Directory.GetCurrentDirectory();
            _logger.LogInformation("DownloadFileController   " + pathRoot);
            var path = Path.Combine(pathRoot, "strartplus.TaxiStartApp.apk");
            var fs = new FileStream(path, FileMode.Open);

            // Return the file. A byte array can also be used instead of a stream
            return File(fs, "application/octet-stream", "strartplus.TaxiStartApp.apk");
        }    

        
    }
}