using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TravelsalProje.Models;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);
            //from kimden geldiğini belirtiyor - gönderilecek olan kişinin bilgileri
            MimeMessage mimeMessage = new MimeMessage(); // mamimessage nesnesi türettik
            // mailboxadress nesnesi türetip model içindeki mailrequest içindeki name ve sendermail propertileri tanımladık
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "melih.karakus1818@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //mailboxadresde olan name ve sender mail ekledik mime message

            //alacak olan kişinin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail); // bu sefer kullanıcı kimden gidecek ise verileri getirdik
            mimeMessage.To.Add(mailboxAddressTo);//mailboxaddresstodaki bilgileri buraya ekleyip gönderen kişi olarak gösterecektir
 

            var bodybuilder = new BodyBuilder(); // body builderdan bir nesne ürettik
            bodybuilder.TextBody = passwordResetTokenLink; //bizim modeldekine bunu eşitledik
            mimeMessage.Body = bodybuilder.ToMessageBody();//message gönderme işlemi sağladık

            mimeMessage.Subject = "şifre değişiklik talebi";
            //mimeMessage.Body = mailRequest.Body;
            SmtpClient smtpClient = new SmtpClient();//mailkit ile nesne ürettik burada
            smtpClient.Connect("smtp.gmail.com", 587, false);//burada belirtiyoruz mail ile ilgili bilgileri
            smtpClient.Authenticate("melih.karakus1818@gmail.com", "ofasemmxokjusxvr");//şifre yerine googleda verilen iki aşamalı doğrulamadaki şifreyi almalıyız)
            //kulanıcı mail gönderme işlemi authenticate olduğunda göndereceği için işlem budur
            smtpClient.Send(mimeMessage); //gönderen seçildi
            smtpClient.Disconnect(true);

            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                ModelState.AddModelError(resetPasswordViewModel.ConfirmPassword, "Şifreler uyuşmuyor.");
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            } 
            return View();
        }
    }
}