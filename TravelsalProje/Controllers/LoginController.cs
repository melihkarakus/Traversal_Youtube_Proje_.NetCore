using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelsalProje.Models;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //usermanagerdan bir kalıntı almak için kullanılır konstrakçır oluşturulmalıdır.
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p) //UserRegisterViewModel içinde tanımladuğum proportilerle karşılaştırmak için tanımlandı.
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name, //Model içinde tanımladığım UserRegisterViewModel içindeki parametlerle karşılaştırılıyor.
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if (p.Password == p.ConfirmPassword) //şifreler eşit ise alttaki komutlara bakarak şifreyi oluşturucak
            {
                var result = await _userManager.CreateAsync(appUser, p.Password); // result appuser ve parametreden gelen şifreyi result taşıdık.
                if (result.Succeeded) // eğer result doğru olursa return içinde giriş ekranına yönlendiricek.
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors) // eğer result içindeki işlemler yanlış ise bizi aynı sayfada tutup startup ve customıdentity içinde tanımlanan methodlar çalışıcak.
                    {
                        ModelState.AddModelError("", item.Description); // customidentityvalidator komutlarını döndürür.
                    }
                }
            }
            return View(p);
        }




        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSıgnInViewModel p) //siginview modelden kalıntı alındı.
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true); // özellikle sıralama önemli p.username ve p.password gibi
                // signinviewmodel içindeki methodları burada çağırdık username ve password model tarafında string olarak tanımlandırıldı.
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "Member" }); //buradan area içindeki login index erişmem için areas değil area yazılmalıdır. yoksa gitmiyor.
                }
                else
                {
                    return RedirectToAction("SignIn","Login");
                }
            }
            return View();
        }
    }
}
