using JobTaxi.Entity;
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
        public IndexModel(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async void OnGet(string code)
        {
            var iPAddress = HttpContext.Connection.RemoteIpAddress;
            if (code != null)
            {
                var route = _jobRepository.CreateRoutePage(new RoutePage { Name = code });
            }
            Console.WriteLine($"Пришли на страницу landinga {iPAddress} {DateTime.Now}");
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
