using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using JobTaxiService.Dto;
using JobTaxiService.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YandexOauthController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IDataService _dataService;
        public YandexOauthController(IJobRepository jobRepository,
            IDataService dataService) {
            _jobRepository = jobRepository;
            _dataService = dataService;
        }

        [Produces("application/json")]
        public async Task<IActionResult> Get(string code, string token)
        {
            Console.WriteLine("Запрос на авторизацию через яндеркс id");
            try
            {
                if (token != "631DFC6B-5080-4E4B-BBDD-2E74DEFA8025") 
                {
                    return StatusCode(401);
                }
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

                var tookeniser = JsonConvert.DeserializeObject<UserTokenJson>(responseBody);
                var usertooken = _jobRepository.InsertUserToken(new UserToken
                {
                    AccessToken = tookeniser.access_token,
                    ExpiresIn = tookeniser.expires_in,
                    RefreshToken = tookeniser.refresh_token,
                    Scope = tookeniser.scope,
                    TokenType = tookeniser.token_type
                });

                Console.WriteLine(responseBody);
                return new JsonResult(usertooken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(502);
            }
            ////var ss = WebUtility.UrlEncode("таксиработааренда.рф");
            ////var url = $"https://{ss}/";
            //var url = "http://localhost:5226/Oauth";
            //return Redirect(url);
        }

        [Produces("application/json")]
        [Route("token/")]
        public async Task<IActionResult> GetToken(string code, string cid, string deviceId)
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

                var tookeniser = JsonConvert.DeserializeObject<UserTokenJson>(responseBody);
                var usertooken = _jobRepository.InsertUserToken(new UserToken
                {
                    AccessToken = tookeniser.access_token,
                    ExpiresIn = tookeniser.expires_in,
                    RefreshToken = tookeniser.refresh_token,
                    Scope = tookeniser.scope,
                    TokenType = tookeniser.token_type,
                    DeviceId = deviceId,
                    DateEdit = DateTime.Now
                });

                Console.WriteLine(responseBody);
                return new JsonResult(usertooken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(502);
            }           
        }

        [Produces("application/json")]
        [Route("login/info")]
        public async Task<IActionResult> GetLoginInfo(string code, string token, string deviceId)
        {
            Console.WriteLine("Обмен токена на данные о пользователе");
            try
            {
                if (code != "631DFC6B-5080-4E4B-BBDD-2E74DEFA8025")
                {
                    return StatusCode(401);
                }

                var pathBase = "https://login.yandex.ru";
                var client = new HttpClient();
                Uri baseUri = new Uri(pathBase);
                client.BaseAddress = baseUri;

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/info?format=json");
                client.DefaultRequestHeaders.Add("Authorization", "OAuth " + token);
                
                var response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<YandexProfil>(responseBody);

                var userResult = _dataService.CheckUser(user, deviceId);

                Console.WriteLine(responseBody);
                return new JsonResult(userResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(502);
            }
        }
    }
}
