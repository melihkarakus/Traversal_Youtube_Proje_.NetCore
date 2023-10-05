using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TravelsalProje.Areas.Member.Controllers
{
    [Area("Member")] //area içinde class tanımladığımızda sayfayı açmak için etrebitü tanımlamalıyız
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationsDal()); //busineslayer içinde concrete klasöründe çağırdık efdal ise datalayerdan abstran içinden çağırdık 
        public IActionResult Index()
        {
            var values = destinationManager.TGetlist(); // datamızda girilen destination bilgilerini sıralamak için kullanılan method
            return View(values);
        }
        public IActionResult CitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in destinationManager.TGetlist() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
