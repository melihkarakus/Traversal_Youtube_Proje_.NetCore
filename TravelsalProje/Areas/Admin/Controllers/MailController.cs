using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelsalProje.Models;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            //from kimden geldiğini belirtiyor - gönderilecek olan kişinin bilgileri
            MimeMessage mimeMessage = new MimeMessage(); // mamimessage nesnesi türettik
            // mailboxadress nesnesi türetip model içindeki mailrequest içindeki name ve sendermail propertileri tanımladık
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","melih.karakus1818@gmail.com"); 
            mimeMessage.From.Add(mailboxAddressFrom); //mailboxadresde olan name ve sender mail ekledik mime message
            
            //alacak olan kişinin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail); // bu sefer kullanıcı kimden gidecek ise verileri getirdik
            mimeMessage.To.Add(mailboxAddressTo);//mailboxaddresstodaki bilgileri buraya ekleyip gönderen kişi olarak gösterecektir
            mimeMessage.From.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder(); // body builderdan bir nesne ürettik
            bodybuilder.TextBody  = mailRequest.Body; //bizim modeldekine bunu eşitledik
            mimeMessage.Body = bodybuilder.ToMessageBody();//message gönderme işlemi sağladık

            mimeMessage.Subject = mailRequest.Subject;
            //mimeMessage.Body = mailRequest.Body;
            SmtpClient smtpClient = new SmtpClient();//mailkit ile nesne ürettik burada
            smtpClient.Connect("smtp.gmail.com", 587, false);//burada belirtiyoruz mail ile ilgili bilgileri
            smtpClient.Authenticate("melih.karakus1818@gmail.com", "Aa19bb85cc");//şifre yerine googleda verilen iki aşamalı doğrulamadaki şifreyi almalıyız)
            //kulanıcı mail gönderme işlemi authenticate olduğunda göndereceği için işlem budur
            smtpClient.Send(mimeMessage); //gönderen seçildi
            smtpClient.Disconnect(true);    
            return View();
        }
    }
}
