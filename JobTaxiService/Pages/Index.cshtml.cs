using JobTaxi.Entity;
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
            
            Console.WriteLine($"Пришли на страницу landinga {iPAddress}");
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
