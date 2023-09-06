using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TravelsalProje.Areas.Member.Models;

namespace TravelsalProje.Areas.Member.Controllers
{
    [Area("Member")] //area içinde çalışıldığı için area tanımı yapılmalıdır.
    [Route("Member/[controller]/[action]")] //yönlendirme vermemiz gerekiyor yoksa gitmeyebilir.
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // burada kullanıcı adı getirttiriyoruz.
            UserEditViewModel userEditViewModel = new UserEditViewModel(); //usereditviewmodel burada çağırıyoruz içindeki verileri bizim usermanagerımız eşitlemek için 
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phonenumber = values.PhoneNumber;

            return View(userEditViewModel); //userviewmodel içine atılan verileri burada çağırmamıza yarıyor.
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); // burada kullanıcı adı getirttiriyoruz.
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); //şart koyduk
                var extentions = Path.GetExtension(p.Image.FileName); // resmi filename olarak klasörde tuttuk
                var imagename = Guid.NewGuid() + extentions; // image klasörde birleştirdik
                var savelocation = resource + "/wwwroot/UserImages/" + imagename; // bizim projemizdeki wwwroot içindeki image klasörü ile imagename birleştirdik
                var stream = new FileStream(savelocation, FileMode.CreateNew); // kullanıcı oluşturduğu dizini kaydetmemize yarıyor 
                await p.Image.CopyToAsync(stream); //image kopyalaryıp bunu kullanıcının oluşturduğu dizine atıyoruz
                user.ImageUrl = imagename; //url ile image eşitledik 
            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.PhoneNumber = p.phonenumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
