using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal());
        public IActionResult Index() //Destnations sayfasını view oluşturup sayfayı açmak için index oluşturuyoruz
        {
            var values = destinationManager.TGetlist(); //destination sayfasındaki şehirleri tanımlaması ve komple getirilmesi için yazılan method
            return View(values);
        }
        [HttpGet]
        public IActionResult DestinationDetails(int id) //destination detayları için kullanılan method 
        {
            ViewBag.i = id;//destinasyonları detayları idye göre getirmek için veya göstermek için kullanılan method
            var values = destinationManager.TGetByID(id); // destination detaylarını yani şehirlerin tamamını idye göre getirme methodu
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destinations p)
        {
            return View();
        }
    }
}
