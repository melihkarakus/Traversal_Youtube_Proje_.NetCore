using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelsalProje.ViewComponents.Default
{
    public class _Statistics : ViewComponent //ViewComponent tarafında kullanılması için eklenmesi gereken method
	{
        public IViewComponentResult Invoke()
        {
            using var c = new Context(); //Databasemizdeki sınıfları çağırdık
            ViewBag.v1 = c.Destinations.Count(); //database sınıfına tanımladığımız c parametresini datadaki sınıflarımızdan toplamını getirttik
            ViewBag.v2 = c.Guides.Count(); //database sınıfına tanımladığımız c parametresini datadaki sınıflarımızdan toplamını getirttik
			ViewBag.v3 = "285"; 
            return View();
        }
    }
}
