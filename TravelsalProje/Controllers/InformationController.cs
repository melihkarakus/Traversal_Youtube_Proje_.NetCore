using Microsoft.AspNetCore.Mvc;

namespace TravelsalProje.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
