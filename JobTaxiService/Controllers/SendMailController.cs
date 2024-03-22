using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace JobTaxiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : ControllerBase
    {
        [HttpGet]
        public async Task<bool> Get()
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя                
                MailAddress from = new MailAddress("ashurkovav@yandex.ru", "таксиработааренда.рф");
                // кому отправляем
                MailAddress to = new MailAddress("den.podkosov@mail.ru", "Client");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Денис, привет. Тест прошел успешно";
                // текст письма
                m.Body = "<h2>Письмо-тест работы smtp-клиента yandex</h2>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                using (SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("ashurkovav", "bljbyqjxmdbkuwgy");
                    smtp.Timeout = 900000;
                    Thread.Sleep(500);
                    smtp.Send(m);
                    Console.WriteLine("Сообщенине успешно отправлено");
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
