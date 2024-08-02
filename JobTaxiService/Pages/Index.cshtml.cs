using JobTaxi.Entity;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace JobTaxiService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILogger _logger;
        public IndexModel(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }
        public async void OnGet(string code)
        {
            var iPAddress = HttpContext.Connection.RemoteIpAddress;
            Console.WriteLine($"Пришли на страницу landinga {iPAddress} {DateTime.Now}");
            try
            {
                
                if (code != null)
                {
                    _logger.LogInformation($"Пришли на страницу landinga {iPAddress} {DateTime.Now} {code}");
                    var route = _jobRepository.CreateRoutePage(new RoutePage { Name = code });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
