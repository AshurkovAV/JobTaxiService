using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using JobTaxiService.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http.Headers;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YandexOauthController : ControllerBase
    {
        
        [Produces("application/json")]        
        public async void Get(string code)
        {
            Console.WriteLine("Запрос на авторизацию через яндеркс id");
            try
            {
                var pathBase = "https://oauth.yandex.ru";
                var client = new HttpClient();
                Uri baseUri = new Uri(pathBase);
                client.BaseAddress = baseUri;

                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                values.Add(new KeyValuePair<string, string>("code", $"{code}"));
                var content = new FormUrlEncodedContent(values);

                var base64EncodedAuthenticationString = "MzZkNTEzNDcyZDkyNGVhMjkwMTQwMWQ1MTk1OGJjNWM6N2RiYTRlMjVhN2IzNGEyMTk4MmVkZjc0NjZkMDFlZGI=";

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/token");
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                requestMessage.Content = content;

                var response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                Redirect("https://таксиработааренда.рф/");              
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }            
        }       
    }
}
