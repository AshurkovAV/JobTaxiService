using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using JobTaxiService.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace JobTaxiService.Pages
{
    public class OauthModel : PageModel
    {
        private readonly IJobRepository _jobRepository;
        public string Token { get; set; } = "Test";

        public OauthModel(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async void OnGet(string code)
        {
            Console.WriteLine("Запрос на авторизацию через яндеркс id");
            try
            {
                //var pathBase = "https://oauth.yandex.ru";
                //var client = new HttpClient();
                //Uri baseUri = new Uri(pathBase);
                //client.BaseAddress = baseUri;

                //var values = new List<KeyValuePair<string, string>>();
                //values.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                //values.Add(new KeyValuePair<string, string>("code", $"{code}"));
                //var content = new FormUrlEncodedContent(values);

                //var base64EncodedAuthenticationString = "MzZkNTEzNDcyZDkyNGVhMjkwMTQwMWQ1MTk1OGJjNWM6N2RiYTRlMjVhN2IzNGEyMTk4MmVkZjc0NjZkMDFlZGI=";

                //var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/token");
                //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                //requestMessage.Content = content;

                //var response = await client.SendAsync(requestMessage);
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();

                //var tookeniser = JsonConvert.DeserializeObject<UserTokenJson>(responseBody);
                //var usertooken = _jobRepository.InsertUserToken(new UserToken
                //{
                //    AccessToken = tookeniser.access_token,
                //    ExpiresIn = tookeniser.expires_in,
                //    RefreshToken = tookeniser.refresh_token,
                //    Scope = tookeniser.scope,
                //    TokenType = tookeniser.token_type
                //});

                //Console.WriteLine(responseBody);
                //Token = responseBody;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());                
            }
        }
    }
}
