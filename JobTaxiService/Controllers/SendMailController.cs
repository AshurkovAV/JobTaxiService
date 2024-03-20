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
                
                MailAddress from = new MailAddress("ashurkovav@yandex.ru", "Server");
                // кому отправляем
                MailAddress to = new MailAddress("ashurkovav@yandex.ru", "Client");
                // создаем объект сообщения
                MailMessage m = new MailMessage(to, from);
                // тема письма
                m.Subject = "Тест";
                // текст письма
                m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 465;
                    smtp.Host = "smtp.yandex.ru";
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential(to.Address, "kuurhptaxeckviyc");
                    smtp.Timeout = 90000;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Thread.Sleep(1000);
                    smtp.Send(m);
                    Console.Read();
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
