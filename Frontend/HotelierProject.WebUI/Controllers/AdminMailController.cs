using HotelierProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelierProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel mailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //gönderici mail adres
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "emrekeskiner@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //alıcı mail adres
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //mesaj body oluştur
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody= mailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            //mesaj başlık oluştur
            mimeMessage.Subject = mailViewModel.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com",587,false);
            smtpClient.Authenticate("emrekeskiner@gmail.com", "password key");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }

    }
}
