using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text.Json.Serialization;
using JobTaxiService.Dto;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]        
        public async Task<bool> Get()
        {
            Console.WriteLine("Запрос на отправку данных по почте!");
            try
            {
                Mail? mail= new Mail();
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string jsonString = await reader.ReadToEndAsync();
                    // Process the jsonString
                    mail = JsonConvert.DeserializeObject<Mail>(jsonString);
                }
                // отправитель - Объект MailAddress, содержащий адрес отправителя сообщения              
                MailAddress from = new MailAddress(mail.EmailFrom, "таксиработааренда.рф");
                // Объект MailAddress, содержащий адрес получателя сообщения
                MailAddress to = new MailAddress(mail.EmailTo, "client");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = mail.EmailSubject;
                // текст письма
                m.Body = mail.EmailBody;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                using (SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(to.Address, "kuurhptaxeckviyc");
                    smtp.Send(m);
                    Console.WriteLine("Соообщение отправлено" + mail.EmailBody);
                    return true;                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }       
    }
}
