using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() //Destnations sayfasını view oluşturup sayfayı açmak için index oluşturuyoruz
        {
            var values = destinationManager.TGetlist(); //destination sayfasındaki şehirleri tanımlaması ve komple getirilmesi için yazılan method
            return View(values);
        }
       // [HttpGet]
        public async Task <IActionResult> DestinationDetails(int id) //destination detayları için kullanılan method 
        {
            ViewBag.i = id;//destinasyonları detayları idye göre getirmek için veya göstermek için kullanılan method
            ViewBag.destID = id;
            var valu = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = valu.Id;
            var values = destinationManager.TGetDestinationWithGuide(id); // destination detaylarını yani şehirlerin tamamını idye göre getirme methodu
            return View(values);
        }
        //[HttpPost]
        //public IActionResult DestinationDetails(Destinations p)
        //{
        //    return View();
        //}
    }
}
