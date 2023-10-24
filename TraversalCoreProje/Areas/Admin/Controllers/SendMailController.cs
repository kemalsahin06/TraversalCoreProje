using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SendMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // bunu 2 tane mail adresim olmadıgı için birde cok vakit kaybı olmasın diye ugresmadım
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","traversalcore2@gmail.com" );
            mimeMessage.From.Add(mailboxAddressFrom);  // burda göndericek kişinin bilgilerini aldım


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            // burda alacak kişinin bilgilerini yazdım

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body =bodyBuilder.ToMessageBody();


            mimeMessage.Subject = mailRequest.Subject; // konuyu aldık

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalcore2@gmail.com", "123456aA-");
            
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
