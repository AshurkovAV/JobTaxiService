using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxiService.Dto;
using System.IO;

namespace JobTaxiService.Controllers.Toffers
{
    [ApiController]
    [Route("video/[controller]")]
    public class MovFileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public MovFileController(
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
            var path = Path.Combine(pathRoot, "video/mov_bbb.mp4");
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Return the file. A byte array can also be used instead of a stream
            return new FileStreamResult(stream, "video/mp4");
        }

        [HttpGet]
        [Route("reply/")]
        public IActionResult GetReply()
        {
            // Since this is just and example, I am using a local file located inside wwwroot
            // Afterwards file is converted into a stream
            string pathRoot = Directory.GetCurrentDirectory();
            _logger.LogInformation("DownloadFileController   " + pathRoot);
            var path = Path.Combine(pathRoot, "video/reply_1.mp4");
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Return the file. A byte array can also be used instead of a stream
            return new FileStreamResult(stream, "video/mp4");
        }


    }
}